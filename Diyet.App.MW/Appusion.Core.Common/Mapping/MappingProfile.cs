using Appusion.Core.Common.Base;
using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Entities.Product;
using Appusion.Core.Common.Entities.User;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.Product;
using Appusion.Core.Common.ResponseModels.User;
using AutoMapper;


namespace Appusion.Core.Common.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequestPackage, UserEntity>().ReverseMap();

            CreateMap<UserEntity, UserAuthenticateResponsePackage>().ReverseMap();

            CreateMap<DietPlanEntity, GetMealListResponsePackage>().ReverseMap();

            CreateMap<ProductEntity, GetAllProductListResponsePackage>().ReverseMap();

            CreateMap<VerifyOtpRequestPackage, GetUserOtpEntityRequestPackage>().ReverseMap();

            CreateMap<MealEntity, GetMealListResponsePackage>().ReverseMap();
            
            CreateMap<UserChangePasswordRequestPackage, GetUserOtpEntityRequestPackage>().ReverseMap();

            CreateMap<DietPlanEntity, GetDietPlanResponsePackage>().ReverseMap();

            CreateMap<UserEntity, CurrentUser>().ReverseMap();

            CreateMap<SaveDietPlanRequestPackage, DietPlanEntity>().ReverseMap();

            CreateMap<ProductUnitEntity, GetSelectedProductUnitListResponsePackage>().ReverseMap();

            CreateMap<SaveUserDietMealPlanRequestPackage, UserDietPlanDetailEntity>().ReverseMap();
        }
    }
}