using CMVProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CMVProject.DataBase;

// ReSharper disable once InconsistentNaming
public class CMVContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = LocalStorage.db");
    }
}