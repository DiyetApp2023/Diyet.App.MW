using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.ExercisePlan;
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

        public DbSet<UserSessionEntity> UserSession { get; set; }

        public DbSet<MealEntity> Meal { get; set; }

        public DbSet<ProductEntity> Product { get; set; }

        public DbSet<ProductUnitEntity> ProductUnit { get; set; }

        public DbSet<ProductUnitMapEntity> ProductUnitMap { get; set; }

        public DbSet<DietPlanEntity> DietPlan { get; set; }

        public DbSet<UserDietPlanMapEntity> UserDietPlanMap { get; set; }

        public DbSet<UserDietPlanDetailEntity> UserDietPlanDetail { get; set; }

        public DbSet<UserDietPlanMealDetailProductMapEntity> UserDietPlanMealDetailProductMap { get; set; }

        public DbSet<UserDailyActivityEntity> UserDailyActivity { get; set; }

        public DbSet<ActivityEntity> Activity { get; set; }

        public DbSet<UserSessionDetailEntity> UserSessionDetail { get; set; }

        public DbSet<ExerciseDefinitionEntity> ExerciseDefinition { get; set; }

        public DbSet<ExercisePlanEntity> ExercisePlan { get; set; }

        public DbSet<UserExercisePlanMapEntity> UserExercisePlanMap { get; set; }

        public DbSet<UserExerciseEntity> UserExercise { get; set; }
    }
}