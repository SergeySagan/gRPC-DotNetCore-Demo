using Grpc.Core;
using System;
using Wages.Service.Controllers;

namespace Wages.Service
{
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            try
            {
                Server server = new Server
                {
                    Services = { WageService.BindService(new WagesController()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };

                server.Start();

                Console.WriteLine($"Demp Wages server listening on port { Port }");
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();

                server.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: { ex }");
            }
        }
    }
}
