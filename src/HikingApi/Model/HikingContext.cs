using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public class HikingContext : DbContext
    {
        public HikingContext(DbContextOptions<HikingContext> options) 
            : base(options)
        {

        }

        public DbSet<Trail> Trails { get; set; }
        public DbSet<MapPoint> MapPoints { get; set; }
    }
}
