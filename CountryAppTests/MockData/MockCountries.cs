using CountryApp.Dtos;

public class MockData
{
    public static List<CountryDto> GetMockCountries()
    {
        var countries = new List<CountryDto>
        {
            new CountryDto
            {
                Name = "Country1",
                Capital = new string[] { "Capital1", "Capital2" },
                Currencies = null,
                Population = 1000000,
                IsoCode = "ISO1",
                Languages = new List<string> { "English", "Spanish" }
            },
            new CountryDto
            {
                Name = "Country2",
                Capital = new string[] { "Capital3" },
                Currencies = null,
                Population = 2000000,
                IsoCode = "ISO2",
                Languages = new List<string> { "French", "German" }
            }
            // Add more countries as needed
        };

        return countries;
    }
}

