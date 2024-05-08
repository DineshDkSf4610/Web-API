using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroCardApi.Data
{
    [Table("userinfo", Schema = "public")]
    public class UserInfo
    {

        // CardId: number;
        // UserName: string;
        // UserPassword: string;
        // UserPhoneNumber: string;
        // UserEmail: string;
        // Balance: number; 
        [Key]
        public int CardID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public string UserPhoneNumber { get; set; }

        public double Balance { get; set; }

    }
}