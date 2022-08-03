using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Stores.Models;
using Microsoft.AspNetCore.Identity;

namespace Stores.App_Data
{
    //public class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Items> Items { get; set; }
        public DbSet<BinCard> BinCard { get; set; }
        public DbSet<BinCardTransactions> BinCardTransaction { get; set; }
        public DbSet<GoodsReceivedBook> GoodsReceivedBook { get; set; }
        public DbSet<LocalPurchaseOrder> LocalPurchaseOrder { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<RequisitionNote> RequisitionNote { get; set; }
        public DbSet<Suppliers> Supplier { get; set; }
        public DbSet<WayBills> WayBills { get; set; }
        public DbSet<MeasuringUnit> MeasuringUnit { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<IdentityUser> AppUsers { get; set; }
    }

   
}
