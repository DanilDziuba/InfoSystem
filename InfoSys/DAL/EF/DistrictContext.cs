using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.EF
{
    public class DistrictContext : DbContext
    {
        public DbSet<District> districts { get; set; }
        public DbSet<Application> applications { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Land> lands { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<LandLeaseCost> llcs { get; set; }

        public DistrictContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}