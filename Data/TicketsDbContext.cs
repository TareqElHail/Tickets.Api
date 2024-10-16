using Microsoft.EntityFrameworkCore;
using Tickets.Api.Models;

namespace Tickets.Api.Data
{
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ticket> Tickets { get; set; }


    }
}
