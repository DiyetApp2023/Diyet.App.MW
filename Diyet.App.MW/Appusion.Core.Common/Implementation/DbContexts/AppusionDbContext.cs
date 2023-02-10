using Appusion.Core.ExceptionBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Appusion.Core.Common.Implementation.DbContexts
{
    public class AppusionDbContext : DbContext
    {
        public AppusionDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
               return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception ex)
            {
                List<EntityEntry> changedEntries = ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                foreach (var entry in changedEntries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Modified:
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                throw new ApiException(ex.Message,"Uygulamada hata oluştu.",System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}