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
    public class OrderDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public OrderDetailsController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
       

        //GET: api/OrderDetails
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_dbContext.orders.ToList());
        }

        // GET: api/OrderDetails/1
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var medicine = _dbContext.orders.FirstOrDefault(m => m.OrderID == id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }



        //POST: api/OrderDetails

        [HttpPost]
        public IActionResult PostOrder([FromBody] OrderDetails order)
        {
            _dbContext.orders.Add(order);
            _dbContext.SaveChanges();
            //You might want to return CreateAtAction or another apporpriate response
            return Ok();
        }

        //PUT : api/OrderDetails/1
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, [FromBody] OrderDetails order)
        {
            var index = _dbContext.orders.FirstOrDefault(m => m.OrderID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.OrderMedicineName = order.OrderMedicineName;
            index.OrderQuantity = order.OrderQuantity;
            index.OrderStatus = order.OrderStatus;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }

        // DELETE: api/Contacts/1
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _dbContext.orders.FirstOrDefault(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            _dbContext.orders.Remove(order);
            _dbContext.SaveChanges();
            //you might want to return NoContent or another appropriate response
            return Ok();
        }

    }
}