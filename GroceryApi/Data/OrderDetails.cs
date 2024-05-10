using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApi.Data
{
    [Table("orderDetails", Schema = "public")]
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }

        public int BookingID { get; set; }

        public int ProductID { get; set; }

        public int PurchaseCount { get; set; }

        public double PriceOfOrder { get; set; }
    }
}