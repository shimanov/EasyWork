using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyWork.Entities;

namespace EasyWork.DAL
{
    public class EasyWorkContext : DbContext
    {
        public EasyWorkContext() : base("EasyWorkCotext")
        {
            
        }

        public DbSet<ProblemDecision> ProblemDecisions { get; set; }
        public DbSet<Scripts> Scriptses { get; set; }
        public DbSet<Helper> Helpers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
