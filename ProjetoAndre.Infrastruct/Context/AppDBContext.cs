using Microsoft.EntityFrameworkCore;
using ProjetoAndre.Domain.Entities;

namespace ProjetoAndre.Infrastruct.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Ozy@1195;Database=ProjetoAndreTeste");
        }       
    }
}
