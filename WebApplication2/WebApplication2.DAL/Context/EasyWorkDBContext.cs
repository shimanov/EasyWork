using System.Data.Entity;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Context
{
    public class EasyWorkDBContext : DbContext
    {
        private static EasyWorkDBContext _context = null;

        static EasyWorkDBContext()
        {
            _context = new EasyWorkDBContext();
        }

        public static EasyWorkDBContext Instance
        {
            get { return _context; }
        }

        private EasyWorkDBContext() : base("EasyWorkConnectionString")
        {
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }

        public DbSet<ProblemDecision> ProblemDecisions { get; set; }

        public DbSet<Script> Scripts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

    }
}
