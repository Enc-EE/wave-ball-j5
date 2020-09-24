using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WaveBall.Data
{
    public class WaveBallContext : DbContext
    {
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<App> Apps { get; set; }

        public WaveBallContext()
        {
            if (bool.TryParse(Environment.GetEnvironmentVariable("ConnectionStringInFile"), out bool setConnectionString) && setConnectionString)
            {
                Environment.SetEnvironmentVariable("ConnectionString", System.IO.File.ReadLines(@"..\private.txt").First());
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"));
        }
    }

    public class LogEntry
    {
        [Key]
        public long LogEntryId { get; set; }
        [Required]
        public long AppId { get; set; }
        [Required]
        public string Level { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public App App { get; set; }
    }

    public class App
    {
        [Key]
        public long AppId { get; set; }
        [Required]
        public Guid AppGuid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime ModifiedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public List<LogEntry> LogEntries { get; } = new List<LogEntry>();
    }
}
