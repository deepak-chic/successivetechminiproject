
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SuccessiveTechiniProject.WebAPI
{
    public class SuccessiveTechDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public SuccessiveTechDBContext() : base("localConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}