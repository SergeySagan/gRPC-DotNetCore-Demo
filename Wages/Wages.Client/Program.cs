using Grpc.Core;
using System;
using System.Linq;

namespace Wages.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this exciting gRPC demo!"); 
            Console.WriteLine("Enter the Social Security Number for which to get wages:");
            string socialSecurityNumber = Console.ReadLine();

            try
            {
                var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);                
                var client = new WageService.WageServiceClient(channel);

                var response = client.GetWagesBySSN(new WageBySSNRequest { SocialSecurityNumber = socialSecurityNumber });
                if (response?.Wages == null || !response.Wages.Any())
                {
                    Console.WriteLine("Wages not found.");

                    return;
                }

                Console.WriteLine($"The employee wages are a follows:");
                foreach (var wage in response.Wages.OrderBy(x => x.Year).ThenBy(x => x.Quarter))
                {
                    Console.WriteLine($"SSN: { wage.SocialSecurityNumber } Year: { wage.Year } Quarter: { wage.Quarter }"+
                                      $" Amount: { decimal.Parse($"{ wage.Amount }").ToString("c") }");
                }

                // TODO: create decimals in model so that no casting is required:
                // https://docs.microsoft.com/en-us/dotnet/architecture/grpc-for-wcf-developers/protobuf-data-types#decimals

                channel.ShutdownAsync().Wait();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }
    }
}
