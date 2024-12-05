using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetroCardApi.Data;
using Microsoft.EntityFrameworkCore;


namespace MetroCardApi.Controllers
{

    public class ApplicationDBContext : DbContext, IDisposable
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<UserInfo> users { get; set; }

        public DbSet<TravelDetails> travelDetails { get; set; }

        public DbSet<TicketDetails> ticketDetails { get; set; }

    }
}