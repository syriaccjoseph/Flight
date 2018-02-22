using System;
using Microsoft.EntityFrameworkCore;

namespace Flight.Models
{
    public class FlightContext : DbContext
    {

        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
            
        }
        public DbSet<AirRoutes> AirRoutes { get; set; }
    }
}

