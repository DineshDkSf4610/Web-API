using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryApi.Controllers
{
    public class ApplicationDBContext : DbContext, IDisposable
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        public DbSet<UserInfo> users { get; set; }
        public DbSet<ProductDetails> productList { get; set; }
        public DbSet<BookingOrders> bookingList { get; set; }
        public DbSet<OrderDetails> ordersList { get; set; }
    }
}