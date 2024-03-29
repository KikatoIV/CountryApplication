using CountryApp.Dtos;
using System.Collections.Generic;

namespace CountryAppTests.MockData
{
    internal class MockCountries
    {
        public static List<CountryDto> GetMockCountries()
        {
            return new List<CountryDto>
            {
                new CountryDto
                {
                    Name = "United States",
                    Capital = "Washington, D.C.",
                    Currencies = new List<string> { "USD" },
                    Population = 331002651,
                    IsoCode = "USA",
                    Languages = new List<string> { "English" }
                },
                new CountryDto
                {
                    Name = "United Kingdom",
                    Capital = "London",
                    Currencies = new List<string> { "GBP" },
                    Population = 67886011,
                    IsoCode = "GBR",
                    Languages = new List<string> { "English" }
                }
                // Add more countries as needed
            };
        }
    }
}
