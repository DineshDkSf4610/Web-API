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
        public DbSet<Users> users { get; set; }

        public DbSet<MedicineInfo> medicins { get; set; }

        public DbSet<OrderDetails> orders { get; set; }
    }
}