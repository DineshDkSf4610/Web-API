using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalApi.Data;
using Microsoft.EntityFrameworkCore;


namespace MedicalApi.Controllers
{
    public class ApplicationDBContext : DbContext, IDisposable
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public List<Users> users { get; set; }

        public List<MedicineInfo> medicins { get; set; }

        public List<OrderDetails> orders { get; set; }
    }
}