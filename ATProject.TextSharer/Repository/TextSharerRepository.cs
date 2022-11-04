using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TextSharer.Models;

namespace TextSharer.Repository
{
    public class TextSharerRepository : ITextSharerRepository
    {
        private readonly IMongoCollection<TextItem> _collection;
        private readonly DbConfiguration _settings;

        public TextSharerRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;

            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);

            _collection = database.GetCollection<TextItem>(_settings.CollectionName);
        }

        public Task<TextItem> GetByCodeAsync(string code)
        {
            return _collection.Find(u => u.Code == code).FirstOrDefaultAsync();
        }

        public async Task<TextItem> CreateAsync(TextItem text)
        {
            await _collection.InsertOneAsync(text).ConfigureAwait(false);
            return text;
        }
    }
}
