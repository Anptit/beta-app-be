using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BetaTheaterBE.Model
{
    public class Movie : EntityBase
    {
        [BsonElement("title")]
        public string Title { get; set; } = null!;

        [BsonElement("description")]
        public string Description { get; set; } = null!;

        [BsonElement("duration")]
        public int Duration { get; set; }

        [BsonElement("genres")]
        public List<string> Genres { get; set; } = new();

        [BsonElement("language")]
        public string Language { get; set; } = null!;

        [BsonElement("director")]
        public string Director { get; set; } = null!;

        [BsonElement("cast")]
        public List<string> Cast { get; set; } = new();

        [BsonElement("subtitle")]
        public string Subtitle { get; set; } = null!;

        [BsonElement("posterUrl")]
        public string? PosterUrl { get; set; }

        [BsonElement("trailerUrl")]
        public string? TrailerUrl { get; set; } = null!;

        [BsonElement("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;
    }
}
