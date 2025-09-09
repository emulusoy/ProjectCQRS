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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //iliski olusturma 2 tane id kullandigimiz icin bir taraftaki 2 idyi diger tarafaki tek id ile birlestirme
            //has foreigin key hangi sutunu iliskiledireceksin onu secer1

            modelBuilder.Entity<Reservation>().HasOne(x => x.PickUpLocation).WithMany(y => y.PickUpReservation).HasForeignKey(z => z.PickUpLocationID).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Reservation>().HasOne(x => x.DropOffLocation).WithMany(y => y.DropOffReservation).HasForeignKey(z => z.DropOffLocationID).OnDelete(DeleteBehavior.ClientSetNull);
        }

    }
}
