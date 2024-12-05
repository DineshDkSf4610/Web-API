using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApi.Data
{
    [Table("productDetails", Schema = "public")]
    public class ProductDetails
    {
        [Key]
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int AvailableQty { get; set; }

        public double PerPrice { get; set; }

        public DateTime ExpireDate { get; set; }

        public string[] ProductImg { get; set; }

        public DateTime PurchaseDate { get; set; }

    }
}