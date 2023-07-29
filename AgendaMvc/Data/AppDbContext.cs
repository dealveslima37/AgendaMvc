using AgendaMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMvc.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

    }
}
