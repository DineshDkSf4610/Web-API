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
    public class TravelDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public TravelDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        //GET: api/OrderDetails
        [HttpGet]
        public IActionResult GetTravelDetails()
        {
            return Ok(_dbContext.travelDetails.ToList());
        }

        // GET: api/OrderDetails/1
        [HttpGet("{id}")]
        public IActionResult GetTravelDetails(int id)
        {
            var medicine = _dbContext.travelDetails.FirstOrDefault(m => m.TravelID == id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }



        //POST: api/OrderDetails

        [HttpPost]
        public IActionResult PostTravel([FromBody] TravelDetails travels)
        {
            _dbContext.travelDetails.Add(travels);
            _dbContext.SaveChanges();
            //You might want to return CreateAtAction or another apporpriate response
            return Ok();
        }

        //PUT : api/OrderDetails/1
        // [HttpPut("{id}")]
        // public IActionResult PutOrder(int id, [FromBody] TravelDetails order)
        // {
        //     var index = _dbContext.travelDetails.FirstOrDefault(m => m.TravelID == id);
        //     if (index == null)
        //     {
        //         return NotFound();
        //     }
        //     index. = order.OrderMedicineName;
        //     index.OrderQuantity = order.OrderQuantity;
        //     index.OrderStatus = order.OrderStatus;
        //     _dbContext.SaveChanges();
        //     //You might want to return NoContent or another appropriate response
        //     return Ok();
        // }

        // DELETE: api/Contacts/1
        [HttpDelete("{id}")]
        public IActionResult DeleteTravelDetails(int id)
        {
            var order = _dbContext.travelDetails.FirstOrDefault(m => m.TravelID == id);
            if (order == null)
            {
                return NotFound();
            }
            _dbContext.travelDetails.Remove(order);
            _dbContext.SaveChanges();
            //you might want to return NoContent or another appropriate response
            return Ok();
        }
    }
}