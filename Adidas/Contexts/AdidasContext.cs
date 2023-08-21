using Adidas.Models;
using Microsoft.EntityFrameworkCore;

namespace Adidas.Contexts

{
    public class AdidasContext : DbContext
    {
        public AdidasContext() { }
        public AdidasContext(DbContextOptions<AdidasContext> options) : base(options) 
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured )
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-OH3S7OG\\SQLEXPRESS; initial catalog = Adidas;Integrated Security = True; TrustServerCertificate=True");
            }
        }
        public DbSet<Tênis> Tênis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
