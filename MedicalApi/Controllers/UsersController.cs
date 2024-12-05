using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public UsersController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        // private static List<Users> _Users = new List<Users>
        // {
        //     //Add more Users here if needed
        //     new Users {UserID = 1, UserEmail = "dinesh@gmail.com", UserPassword = "123456", UserPhoneNumber = "6384225424", Balance = 0},
        //     new Users {UserID = 2, UserEmail = "kumar@gmail.com", UserPassword = "123456", UserPhoneNumber = "6384225424", Balance = 0}
        // };

        //GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dbContext.users.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _dbContext.users.FirstOrDefault(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult PutMedicine(int id, [FromBody] Users medicine)
        {
            var index = _dbContext.users.FirstOrDefault(m => m.UserID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.UserEmail = medicine.UserEmail;
            index.UserPassword = medicine.UserPassword;
            index.UserPhoneNumber = medicine.UserPhoneNumber;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }
        //POST

        [HttpPost]
        public IActionResult AddUser([FromBody] Users user)
        {
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}