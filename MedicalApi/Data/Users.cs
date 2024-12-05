using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApi.Data
{
    [Table("users", Schema = "public")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public string UserPhoneNumber { get; set; }

        public double Balance { get; set; }


    }
}