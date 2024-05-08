using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroCardApi.Data
{
    [Table("traveldetails", Schema = "public")]
    public class TravelDetails
    {
        // travelID: number,
        // cardID: number,
        // fromLocation: string,
        // toLocation: string
        // date: string,
        // travelCost: number
        [Key]
        public int TravelID { get; set; }

        public int CardID { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public DateTime Date { get; set; }

        public double TravelCost { get; set; }

    }
}