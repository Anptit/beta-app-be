namespace BetaTheaterBE.Model
{
    public class Room : EntityBase
    {
        public string CinemaId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public SeatLayout Seat { get; set; } = new();
    }

    public class SeatLayout
    {
        public List<string> Rows { get; set; } = new();
        public int Columns { get; set; }
    }
}