using BetaTheaterBE.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BetaTheaterBE.Service
{
    public class GenericMongoService<T> where T : EntityBase
    {
        protected readonly IMongoCollection<T> _collection;

        public GenericMongoService(IOptions<MongoDbSettings> settings, string collectionName)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id) =>
            await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T item)
        {
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = ObjectId.GenerateNewId().ToString();
            }

            item.CreatedAt = DateTime.UtcNow;
            item.UpdatedAt = item.CreatedAt;

            await _collection.InsertOneAsync(item);
        }

        public async Task UpdateAsync(string id, T updated)
        {
            updated.UpdatedAt = DateTime.UtcNow;
            await _collection.ReplaceOneAsync(e => e.Id == id, updated);
        }

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(e => e.Id == id);

    }
}
