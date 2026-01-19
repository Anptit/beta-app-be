namespace BetaTheaterBE.Model
{
    public class Showtime : EntityBase
    {
        public string MovieId { get; set; } = string.Empty;
        public string RoomId { get; set; } = string.Empty;
        public string CinemaId { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public List<BookedSeat> BookedSeats { get; set; } = new();
    }
}