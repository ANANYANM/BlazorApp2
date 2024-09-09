namespace BlazorApp2.Data;
using Microsoft.EntityFrameworkCore;
using BlazorApp2.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Ticket> Tickets { get; set; }
}
