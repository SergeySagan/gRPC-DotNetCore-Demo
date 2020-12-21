using System.Threading.Tasks;
using Grpc.Core;
using Wages.Service.Helpers;
using static WageService;

namespace Wages.Service.Controllers
{
    internal class WagesController : WageServiceBase
    {
        public override Task<WageResponse> GetWagesBySSN(WageBySSNRequest request, ServerCallContext context)
        {
            var testData = new TestData();

            var response = new WageResponse();
            response.Wages.AddRange(testData.GetWages(request.SocialSecurityNumber));

            return Task.FromResult(response);
        }
    }
}