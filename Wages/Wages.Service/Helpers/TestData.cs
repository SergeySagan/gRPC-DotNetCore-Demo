using System.Collections.Generic;

namespace Wages.Service.Helpers
{
    internal class TestData
    {
        public List<Wage> GetWages(string socialSecurityNumber)
        {
            return new List<Wage>
            {
                new Wage
                {
                    SocialSecurityNumber = socialSecurityNumber,
                    Year = 2020,
                    Quarter = 1,
                    Amount = 750
                },
                new Wage
                {
                    SocialSecurityNumber = socialSecurityNumber,
                    Year = 2020,
                    Quarter = 2,
                    Amount = 1250
                },
                new Wage
                {
                    SocialSecurityNumber = socialSecurityNumber,
                    Year = 2020,
                    Quarter = 3,
                    Amount = 1000
                },
                new Wage
                {
                    SocialSecurityNumber = socialSecurityNumber,
                    Year = 2020,
                    Quarter = 4,
                    Amount = 500
                }
            };
        }
    }
}
