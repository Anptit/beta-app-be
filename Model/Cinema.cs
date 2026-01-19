namespace BetaTheaterBE.Model
{
    public class Cinema : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Status { get; set; } = "active";
    }
}