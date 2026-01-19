using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BetaTheaterBE.Model
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
