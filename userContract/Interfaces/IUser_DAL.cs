using System;
using userContract.DTO;
namespace userContract.Interfaces
{
	public interface IUser_DAL
	{
		public Task<userDTO> GetUser(string userid);
	}
}

