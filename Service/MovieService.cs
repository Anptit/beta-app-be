using BetaTheaterBE.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace BetaTheaterBE.Service
{
    public class MovieService : GenericMongoService<Movie>
    {
        public MovieService(IOptions<MongoDbSettings> settings) : base(settings, "movies") { }

        public async Task<Movie?> GetByTitleAsync(string title)
        {
            return await _collection
                .Find(m => string.Equals(m.Title.Trim(), title.Trim(), StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();
        }
    }
}
