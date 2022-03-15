using MongoDB.Bson;
using MongoDB.Driver;
using MonkeyShelterAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyShelterAPI.Repositories
{
    public class MongoDBMonkeyRepo : IMonkeysRepository
    {
        private const string databaseName = "MonkeyShelter";
        private const string collectionName = "monkeycollection";
        private readonly IMongoCollection<Monkey> monkeysCollection;
        private readonly FilterDefinitionBuilder<Monkey> filterBuilder = Builders<Monkey>.Filter;

        public MongoDBMonkeyRepo(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            monkeysCollection = database.GetCollection<Monkey>(collectionName);
        }

        public async Task CreateMonkeyAsync(Monkey monkey)
        {
            await monkeysCollection.InsertOneAsync(monkey);
        }

        public async Task DeleteMonkeyAsync(Guid id)
        {
            var filter = filterBuilder.Eq(monkey => monkey.Id, id);
            await monkeysCollection.DeleteOneAsync(filter);
        }

        public async Task<Monkey> GetMonkeyAsync(Guid id)
        {
            var filter = filterBuilder.Eq(monkey => monkey.Id, id);
            return await monkeysCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            return await monkeysCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateMonkeyAsync(Monkey monkey)
        {
            var filter = filterBuilder.Eq(existingMonkey => existingMonkey.Id, monkey.Id);
            await monkeysCollection.ReplaceOneAsync(filter, monkey);
        }
    }
}