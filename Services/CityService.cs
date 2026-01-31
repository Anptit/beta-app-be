using BetaTheaterBE.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BetaTheaterBE.Services
{
    public class CityService : GenericMongoService<City>
    {
        public CityService(IOptions<MongoDbSettings> settings) : base(settings, "Cities") { }

        public async Task<bool> CheckCityCodeExistsAsync(string cityCode)
        {
            if (string.IsNullOrWhiteSpace(cityCode))
                return false;

            var count = await _collection.CountDocumentsAsync(c => string.Equals(c.CityCode.ToLower(), cityCode.ToLower()));
            return count > 0;
        }

        public async Task<City?> GetByIdAsync(string id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<City> UpdateAsync(string id)
        {
            
        }
    }
}