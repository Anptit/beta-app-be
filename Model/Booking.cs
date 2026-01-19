namespace BetaTheaterBE.Model
{
    public class Booking : EntityBase
    {
        public string UserId { get; set; } = string.Empty;
        public string ShowtimeId { get; set; } = string.Empty;
        public List<BookedSeat> Seats { get; set; } = new();
        public string Status { get; set; } = "pending";
    }
}