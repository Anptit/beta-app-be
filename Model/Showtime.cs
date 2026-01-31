namespace BetaTheaterBE.Model
{
    public enum SeatStatus
    {
        AVAILABLE,
        BOOKED,
        SOLD
    }

    public class Showtime : EntityBase
    {
        public string MovieId { get; set; } = string.Empty;
        public string RoomId { get; set; } = string.Empty;
        public string CinemaId { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string, SeatStatus> BookedSeats { get; set; } = new();
    }
}