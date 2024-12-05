using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
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

        [HttpPost("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _dbContext.users.FirstOrDefault(list => list.UserID == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserInfo user)
        {
            var getUser = _dbContext.users.FirstOrDefault(list => list.UserID == id);
            if (getUser == null)
            {
                return NotFound();
            }
            getUser.UserName = user.UserName;
            getUser.UserEmailID = user.UserEmailID;
            getUser.PhoneNumber = user.PhoneNumber;
            getUser.Balance = user.Balance;
            getUser.PassWord = user.PassWord;
            _dbContext.SaveChanges();
            return Ok(user);
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