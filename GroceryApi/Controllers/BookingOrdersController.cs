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
    public class BookingOrdersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public BookingOrdersController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }
        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(_dbContext.bookingList.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = _dbContext.bookingList.FirstOrDefault(list => list.BookingID == id);

            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] BookingOrders booking)
        {
            var getBooking = _dbContext.bookingList.FirstOrDefault(list => list.BookingID == id);
            if (getBooking == null)
            {
                return NotFound();
            }
            getBooking.BookingStatus = booking.BookingStatus;
            getBooking.TotalPrice = booking.TotalPrice;
            getBooking.DateOfBooking = booking.DateOfBooking;
            _dbContext.SaveChanges();
            return Ok(getBooking);
        }

        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingOrders booking)
        {
            _dbContext.bookingList.Add(booking);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _dbContext.bookingList.FirstOrDefault(list => list.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            _dbContext.bookingList.Remove(booking);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}