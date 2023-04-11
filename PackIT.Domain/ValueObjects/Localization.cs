namespace PackIT.Domain.ValueObjects
{
    public record Localization(string City, string Country)
    {
        public static Localization Create(string value)
        {
            var splitLozalization = value.Split(',');
            return new Localization(splitLozalization.First(), splitLozalization.Last());
        }

        public override string ToString()
            => $"{City}, {Country}";
    }
}
