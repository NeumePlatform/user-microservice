using System;
using MongoDB.Driver;
using userContract.DTO;
namespace userContract.Interfaces
{
	public interface IUser_DAL
	{
		public Task<userDTO> GetUser(string userid);

		public Task<UpdateResult> UpdateUserSubscription(string userid);

    }
}

