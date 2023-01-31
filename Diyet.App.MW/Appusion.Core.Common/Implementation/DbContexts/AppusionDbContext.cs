using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Appusion.Core.Common.Implementation.DbContexts
{
    public class AppusionDbContext : DbContext
    {
        public AppusionDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public override int SaveChanges()
        {
            var result = 0;
            try
            {
                result = base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;

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
                throw ex;

            }
            return result;
        }
    }
}