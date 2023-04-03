using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeededDatabase.Models;
using SeededDatabase.Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeededDatabase.Context
{
    public class SeededDatabaseContext : DbContext
    {
        public SeededDatabaseContext() 
        {
            var newDatabaseCreated = Database.EnsureCreated();
            if (newDatabaseCreated)
            {
                var seeder = new SeedFromConfigFiles(this);
                seeder.ImportCalculationReferences();
            }
            //Database.
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            optionsBuilder
               .UseSqlServer(configuration.GetConnectionString("SeederDb"));
        }

        public virtual DbSet<CalculationReference> CalculationReferences { get; set; } = null!;
        public virtual DbSet<CalculationData> CalculationData { get; set; } = null!;
        public virtual DbSet<FrontendGauge> FrontendGauges { get; set; } = null!;

    }
}
