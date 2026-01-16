using BetaTheaterBE.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace BetaTheaterBE.Service
{
    public class MovieService
    {
        private readonly IMongoCollection<Movie> _moviesCollection;

        public MovieService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _moviesCollection = database.GetCollection<Movie>(settings.Value.MoviesCollectionName);
        }

        public async Task<List<Movie>> GetAsync() =>
            await _moviesCollection.Find(_ => true).ToListAsync();

        public async Task<Movie?> GetAsync(string id) =>
            await _moviesCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task<Movie?> GetByTitleAsync(string title)
        {
            var filter = Builders<Movie>.Filter.Regex("title", new BsonRegularExpression($"^{Regex.Escape(title)}$", "i"));
            return await _moviesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Movie newMovie) =>
            await _moviesCollection.InsertOneAsync(newMovie);

        public async Task UpdateAsync(string id, Movie updatedMovie) =>
            await _moviesCollection.ReplaceOneAsync(m => m.Id == id, updatedMovie);

        public async Task RemoveAsync(string id) =>
            await _moviesCollection.DeleteOneAsync(m => m.Id == id);
    }
}
