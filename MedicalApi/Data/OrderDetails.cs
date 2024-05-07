using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApi.Data
{
     [Table("orderDetails", Schema = "public")]
    // enum OrderStatus {Ordered, Cancelled};
    public class OrderDetails
    {
        //      OrderId: string;
        // UserID: string;
        // OrderMedicineID: string;
        // OrderMedicineName: string;
        // OrderQuantity: number;
        // OrderDate: Date;
        // TotalPrice: number;
        // OrderStatus: string;
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public int OrderMedicineID { get; set; }

        public string OrderMedicineName { get; set; }

        public int OrderQuantity { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public string OrderStatus { get; set; }

    }
}