using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using service_users.DTO;
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
        public async Task<IUser> GetUser(string userid)
        {
            IUser user = await _user.GetUser(userid);

            return user;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            return Ok();
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

