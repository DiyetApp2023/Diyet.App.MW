using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.Interface.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Appusion.Core.Common.Base
{
    public class CurrentUser
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string GsmNumber { get; set; }

        public string EmailAddress { get; set; }

        public string HashedPassword { get; set; }

        public bool EmailAddressConfirmed { get; set; }

        public DateTime CreateDate { get; set; }

        public static CurrentUser Create(IServiceProvider serviceProvider)
        {
            var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor) ?.HttpContext;
            var userId = httpContext.Items["UserId"];
            var userEntityRepository = httpContext.RequestServices.GetRequiredService<IUserEntityRepository>();
            var userEntity =  userEntityRepository.GetUserEntityById(Convert.ToInt64(userId));
            var mapper = serviceProvider.GetService(typeof(IMapper)) as IMapper;
            var currentUser = mapper.Map<UserEntity, CurrentUser>(userEntity.Result);
            return currentUser;
        }
    }
}