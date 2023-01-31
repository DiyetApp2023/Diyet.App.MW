using Appusion.Core.Common.Entities.User;
using Microsoft.EntityFrameworkCore;


namespace Appusion.Core.Common.Implementation.DbContexts
{
    public class DietDbContext : AppusionDbContext
    {
        public DietDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<UserEntity> User { get; set; }

        public DbSet<UserActivation> UserActivation { get; set; }

        //public DbSet<Parameter> Parameter { get; set; }

        //public DbSet<TempSession> TempSession { get; set; }

        //public DbSet<PageDefinition> PageDefinition { get; set; }

        //public DbSet<Application> Application { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Parameter>().HasNoKey();
        }
    }
}