using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManageMVC.Models;

namespace StockManageMVC.Repository
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<WarehouseTransactionModel> WarehouseTransactions { get; set; }
        public DbSet<SupplierModel> Supplier { get; set; }
    }
}

//Add-Migration SupplierMigartion
//Update-database
