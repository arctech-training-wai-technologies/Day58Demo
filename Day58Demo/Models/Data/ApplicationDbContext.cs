using Microsoft.EntityFrameworkCore;

namespace Day58Demo.Models.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=UserManagement;Integrated Security=True");
    }
}