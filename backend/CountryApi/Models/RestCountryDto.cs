namespace CountryApi.Models
{
    public class RestCountryDto
    {
        public NameDto Name { get; set; }
        public FlagsDto Flags { get; set; }
        public int Population { get; set; }
        public List<string>? Capital { get; set; }
    }

    public class NameDto
    {
        public string Common { get; set; }
    }

    public class FlagsDto
    {
        public string Png { get; set; }
    }
}
