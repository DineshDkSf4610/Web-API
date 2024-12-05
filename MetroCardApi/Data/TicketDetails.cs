using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroCardApi.Data
{
    [Table("ticketdetails", Schema = "public")]
    public class TicketDetails
    {
        // ticketID: number,
        // fromLocation: string,
        // toLocation: string,
        // ticketPrice: number
        [Key]
        public int TicketID { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public double TicketPrice { get; set; }

    }
}