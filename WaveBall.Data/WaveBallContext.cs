using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveBall.Data
{
    public class WaveBallContext : DbContext
    {
        public DbSet<StartUp> StartUps { get; set; }

        public WaveBallContext()
        {
            if (Boolean.TryParse(Environment.GetEnvironmentVariable("ConnectionStringInFile"), out bool setConnectionString) && setConnectionString)
            {
                Environment.SetEnvironmentVariable("ConnectionString", System.IO.File.ReadLines("private.txt").First());
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));
        }
    }

    public class StartUp
    {
        public long StartUpId { get; set; }
        public DateTime DateTime { get; set; }
        public string Info { get; set; }
    }
}
