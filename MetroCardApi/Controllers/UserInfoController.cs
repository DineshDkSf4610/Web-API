using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetroCardApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MetroCardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public UserInfoController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dbContext.users.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _dbContext.users.FirstOrDefault(m => m.CardID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UserInfo user)
        {
            var index = _dbContext.users.FirstOrDefault(m => m.CardID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.UserEmail = user.UserEmail;
            index.UserPassword = user.UserPassword;
            index.UserPhoneNumber = user.UserPhoneNumber;
            index.Balance = user.Balance;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserInfo user)
        {
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}