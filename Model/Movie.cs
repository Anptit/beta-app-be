using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BetaTheaterBE.Model
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

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

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
