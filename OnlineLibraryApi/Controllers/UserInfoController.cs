using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryApi.Data;

namespace OnlineLibraryApi.Controllers
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
            return Ok(_dbContext.userList.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _dbContext.userList.FirstOrDefault(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UserInfo user)
        {
            var index = _dbContext.userList.FirstOrDefault(m => m.UserID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.EmailID = user.EmailID;
            index.Password = user.Password;
            index.MobileNumber = user.MobileNumber;
            index.Balance = user.Balance;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserInfo user)
        {
            _dbContext.userList.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}