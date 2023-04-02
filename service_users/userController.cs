using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using userBusiness.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace service_users
{
    [Route("api/[controller]")]
    public class userController : Controller
    {
        private readonly IUser _user;

        public userController(IUser user)
        {
            _user = user;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IUser> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{userid}")]
        public async Task<IUser> Get(string userid)
        {
            IUser user = await _user.GetUser(userid);

            return user;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

