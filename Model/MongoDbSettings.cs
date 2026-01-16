namespace BetaTheaterBE.Model
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string MoviesCollectionName { get; set; } = null!;
    }
}
