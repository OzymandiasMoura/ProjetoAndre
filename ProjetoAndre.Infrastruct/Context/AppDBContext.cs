using Microsoft.EntityFrameworkCore;
using ProjetoAndre.Domain.Entities;
using Serilog;

namespace ProjetoAndre.Infrastruct.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Combo> combos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1107;Database=ProjetoAndreTeste");
        }
        public bool TestConnection()
        {
            try
            {
                this.Database.OpenConnection();
                this.Database.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"Error testing database connection: {ex.Message}");
                Console.WriteLine($"Error testing database connection: {ex.Message}");
                return false;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasIndex(p => p.BarCode).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Product>().HasOne(p => p.Combo).WithMany(c => c.ProductsInCombo).HasForeignKey(p => p.ComboId);


            modelBuilder.Entity<Combo>().HasKey(c => c.Id);
            modelBuilder.Entity<Combo>().HasIndex(c => c.Code).IsUnique();
            modelBuilder.Entity<Combo>().HasIndex(c => c.Name).IsUnique();
            
        }
    }
}
