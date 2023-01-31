using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.Entities.User;
using Microsoft.EntityFrameworkCore;


namespace Appusion.Core.Common.Implementation.DbContexts
{
    public class DietDbContext : AppusionDbContext
    {
        public DietDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<UserEntity> User { get; set; }

        public DbSet<UserActivationEntity> UserActivation { get; set; }

        public DbSet<UserOtpEntity> UserOtp { get; set; }

        public DbSet<MealEntity> Meal { get; set; }

        public DbSet<ProductEntity> Product { get; set; }

        public DbSet<ProductUnitEntity> ProductUnit { get; set; }

        public DbSet<ProductUnitMapEntity> ProductUnitMap { get; set; }
    }
}