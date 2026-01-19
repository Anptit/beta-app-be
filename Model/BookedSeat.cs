namespace BetaTheaterBE.Model
{
    public class BookedSeat
    {
        public string SeatCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}