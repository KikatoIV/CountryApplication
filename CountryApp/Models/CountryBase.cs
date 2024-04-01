// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class Name
{
    public string? common { get; set; }
}

public class Root
{
    public Name? name { get; set; }
    public List<string>? tld { get; set; }
    public string? cca2 { get; set; }
    public string? ccn3 { get; set; }
    public string? cca3 { get; set; }
    public string? cioc { get; set; }
    public bool independent { get; set; }
    public string? status { get; set; }
    public bool unMember { get; set; }
    public string[]? capital { get; set; }
    public List<string>? altSpellings { get; set; }
    public string? region { get; set; }
    public string? subregion { get; set; }
    public int population { get; set; }
    public Flags? flags { get; set; }
    public Dictionary<string, string>? languages { get; set; }
    public Dictionary<string, Dictionary<string, string>>? currencies { get; set; }
}

public class currency
{
    public string? Name { get; set; }
    public string? Symbol { get; set; }
}

public class Flags
{
    public string? png { get; set; }
    public string? svg { get; set; }
    public string? alt { get; set; }
}
