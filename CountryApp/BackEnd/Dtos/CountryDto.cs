namespace CountryApp.Dtos
{
    public class CountryDto
    {
        public string? Name { get; set; }
        public string[]? Capital { get; set; }
        public IEnumerable<string>? Currencies { get; set; }
        public int Population { get; set; }
        public string? IsoCode { get; set; }
        public IReadOnlyCollection<string>? Languages { get; set; }
        public string? flag { get; set; }
    }
}
