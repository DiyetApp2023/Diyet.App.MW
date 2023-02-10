namespace Appusion.Core.Common.Base
{
    public interface ICurrentUser
    {
        Task<CurrentUser> Create(IServiceProvider serviceProvider);
    }
}