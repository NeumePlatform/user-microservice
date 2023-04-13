using System;
using userContract.Interfaces;
using userContract.DTO;
using MongoDB.Driver;

namespace userBusiness.Models
{
	public class User : IUser
	{
        private readonly IUser_DAL _userService;

        public string userId { get; set; }
        public string userName { get; set; }
        public string userDisplayName { get; set; }
        public string userEmail { get; set; }
        public bool userIsPremium { get; set; }

        public User(IUser_DAL userService)
        {
            _userService = userService;
        }

        public User(userDTO userDto)
        {
            userId = userDto.id;
            userName = userDto.username;
            userDisplayName = userDto.display_name;
            userEmail = userDto.email;
            userIsPremium = userDto.is_premium;
        }

        public async Task<IUser> GetUser(string userid)
        {
            userDTO userDto = await _userService.GetUser(userid);

            IUser user = new User(userDto);

            return user;
        }

        public async Task<UpdateResult> UpdateUserSubscription(string userid)
        {
            return await _userService.UpdateUserSubscription(userid);
        }
    }
}

