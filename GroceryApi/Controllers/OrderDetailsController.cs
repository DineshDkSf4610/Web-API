using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
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
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_dbContext.ordersList.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _dbContext.ordersList.FirstOrDefault(list => list.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderDetails order)
        {
            var getOrder = _dbContext.ordersList.FirstOrDefault(list => list.ProductID == id);
            if (getOrder == null)
            {
                return NotFound();
            }
            getOrder.PurchaseCount = order.PurchaseCount;
            getOrder.PriceOfOrder = order.PriceOfOrder;
            _dbContext.SaveChanges();
            return Ok(getOrder);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDetails order)
        {
            _dbContext.ordersList.Add(order);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            var order = _dbContext.ordersList.FirstOrDefault(list => list.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            _dbContext.ordersList.Remove(order);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}