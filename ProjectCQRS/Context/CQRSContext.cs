using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Entities;

namespace ProjectCQRS.Context
{
    public class CQRSContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MULUSOY\\SQLEXPRESS01;initial catalog=ProjectCQRSDB; integrated Security =true; trust server certificate=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
