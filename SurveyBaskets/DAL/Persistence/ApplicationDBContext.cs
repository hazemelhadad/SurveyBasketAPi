
using SurveyBaskets.DAL.Persistence.EntitiesConfigurations;
using System.Reflection;

namespace SurveyBaskets.DAL.Persistence
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):DbContext(options)
    {
        public DbSet<Poll> polls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
