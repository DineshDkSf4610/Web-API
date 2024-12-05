using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApi.Data
{
    [Table("bookingOrders", Schema = "public")]
    public class BookingOrders
    {
        [Key] public int BookingID { get; set; }

        public int UserID { get; set; }

        public double TotalPrice { get; set; }

        public DateTime DateOfBooking { get; set; }

        public string BookingStatus { get; set; }

    }
}