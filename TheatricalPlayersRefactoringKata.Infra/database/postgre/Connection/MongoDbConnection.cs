using MongoDB.Driver;

namespace TheatricalPlayersRefactoringKata.Infrastructure.Database
{
    public class MongoDbConnection
    {
        private readonly IMongoDatabase _database;

        public MongoDbConnection(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
