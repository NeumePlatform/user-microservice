using System;
namespace userBusiness.Models
{
	public interface IUser
	{
		public string userId { get; set; }
		public string userName { get; set; }
		public string userDisplayName { get; set; }
		public string userEmail { get; set; }
		public bool userIsPremium { get; set; }

		public Task<IUser> GetUser(string userid);
	}
}

