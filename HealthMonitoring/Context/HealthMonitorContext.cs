using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthMonitoring.Context
{
    public class HealthMonitorContext : DbContext
    {
        public DbSet<Entry> Entry { get; set; }
        public DbSet<TypeOfEntry> TypeOfEntrie { get; set; }
        public DbSet<User> User { get; set; }
        public HealthMonitorContext() : base("MainConString") { }
    }
}