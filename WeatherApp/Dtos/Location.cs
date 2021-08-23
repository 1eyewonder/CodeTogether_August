namespace WeatherApp.Dtos
{
    public record Location
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public float Latitude { get; init; }
        public float Longitude { get; init; }
        public int? Distance { get; init; }
    }
}