namespace BetaTheaterBE.Model
{
    public class City : EntityBase
    {
        public string CityCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "active";
    }
}