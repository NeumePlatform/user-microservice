using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace userContract.DTO
{
	public class userDTO
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string id { get; set; }
        public string username { get; set; }
        public string display_name { get; set; }
        public string email { get; set; }
        public bool is_premium { get; set; }
    }
}

