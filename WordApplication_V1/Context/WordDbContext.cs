using Microsoft.EntityFrameworkCore;
using WordApplication_V1.Entities;

namespace WordApplication_V1.Context
{
    public class WordDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }

        public DbSet<Word> Words { get; set; }

        //Migration Managment Öğren.
    }
}
