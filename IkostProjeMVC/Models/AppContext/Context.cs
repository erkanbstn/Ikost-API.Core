using IkostProjeMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IkostProjeMVC.Models.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GEOPC\\SQLEXPRESS;Initial Catalog=IkostDb;Integrated Security=True"); // Revize Edilmeli
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Siparisler>().ToTable("Siparislers");
            modelBuilder.Entity<Siparisler>().HasKey(b => b.SiparisID);

            modelBuilder.Entity<Bayiler>().ToTable("Bayilers");
            modelBuilder.Entity<Bayiler>().HasKey(b => b.BayiID);
        }
        public DbSet<Bayiler> Bayilers { get; set; }
        public DbSet<Siparisler> Siparislers { get; set; }

    }
}
