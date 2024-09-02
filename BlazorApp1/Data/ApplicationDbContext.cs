using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Call> Calls { get; set; }
    // public DbSet<City> Cities { get; set; }
    // public DbSet<Phone> Phones { get; set; }
    // public DbSet<Subscriber> Subscribers { get; set; }
    // public DbSet<Tariff> Tariffs { get; set; }
}