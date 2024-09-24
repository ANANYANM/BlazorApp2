using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp2.Models;


public partial class TicketContext : DbContext
{
    public TicketContext(DbContextOptions<TicketContext> options)
        : base(options)
    {
    }
    public DbSet<Ticket>Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PendingSignUp> PendingSignUps { get; set; }
}

