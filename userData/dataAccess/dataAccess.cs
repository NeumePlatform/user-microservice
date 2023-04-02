using System;
using MongoDB.Driver;

namespace userData.dataAccess
{
	public class dataAccess
	{
		private const string connectionString = "mongodb://localhost:27016";
		private const string databaseName = "neume-users";
		private const string userCollection = "users";

		public IMongoCollection<T> ConnectToMongo<T>(in string collection)
		{
			var client = new MongoClient(connectionString);
			var db = client.GetDatabase(databaseName);
			return db.GetCollection<T>(collection);
		}

		public async Task<List<User>> getAllUsers()
		{
			var usersCollection = ConnectToMongo<User>(userCollection);
			var results = await usersCollection.FindAsync(_ => true);
			return results.ToList();
		}
	}
}

