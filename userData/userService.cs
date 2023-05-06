using System;
using MongoDB.Bson;
using MongoDB.Driver;
using userData.dataAccess;
using userContract.Interfaces;
using userContract.DTO;

namespace userData
{
	public class userService : IUser_DAL
	{
        private const string userCollection = "users";
        dataAccess.dataAccess db = new dataAccess.dataAccess();

        public userService()
		{
            
		}

        public async Task<userDTO> GetUser(string userid)
        {
            var usersCollection = db.ConnectToMongo<User>(userCollection);
            var filter = Builders<User>.Filter.Eq("user_id", userid);
            var results = await usersCollection.FindAsync<User>(filter);
            var list = results.ToList();

            userDTO user = new userDTO();

            foreach(var listUser in list)
            {
                user.id = listUser.user_id;
                user.username = listUser.username;
                user.display_name = listUser.display_name;
                user.email = listUser.email;
                user.is_premium = listUser.is_premium;
            }

            return user;
        }

        public async Task<UpdateResult> UpdateUserSubscription(string userid)
        {
            var usersCollection = db.ConnectToMongo<User>(userCollection);
            var filter = Builders<User>.Filter.Eq("user_id", userid);

            var update = Builders<User>.Update.Set("is_premium", true);
            
            return await usersCollection.UpdateOneAsync(filter, update);
        }
    }
}

