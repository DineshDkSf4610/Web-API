using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApi.Data
{
    [Table("userInfo", Schema = "public")]
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserEmailID { get; set; }

        public string PhoneNumber { get; set; }

        public string PassWord { get; set; }

        public double Balance { get; set; }

    }
}