using Microsoft.EntityFrameworkCore;
using StockManageMVC.Models;

namespace StockManageMVC.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
