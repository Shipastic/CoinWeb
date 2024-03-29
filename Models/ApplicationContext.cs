using Microsoft.EntityFrameworkCore;

namespace CoinWeb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Coin> Coins { get; set; } = null;

        public ApplicationContext() { } 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();    
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>().HasData
                (
                 new Coin { Id = 1, Country = "Italy", Year = 1973, Metal = "Aluminum", Face = "/images/img1.jpg",  Denomination = "5   lire" },
                 new Coin { Id = 2, Country = "Italy", Year = 1980, Metal = "Aluminum", Face = "/images/img2.jpg",  Denomination = "10  lire" },
                 new Coin { Id = 3, Country = "Italy", Year = 1967, Metal = "Steel",    Face = "/images/img3.jpg",  Denomination = "50  lire" },
                 new Coin { Id = 4, Country = "Italy", Year = 1975, Metal = "Steel",    Face = "/images/img4.jpg",  Denomination = "100 lire" },
                 new Coin { Id = 5, Country = "Italy", Year = 1978, Metal = "Bronze",   Face = "/images/img5.jpg",  Denomination = "200 lire" },
                 new Coin { Id = 6, Country = "Italy", Year = 1965, Metal = "Silver",   Face = "/images/img6.jpg",  Denomination = "500 lire" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string conn = Program.configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer( conn );
        }
    }
}
