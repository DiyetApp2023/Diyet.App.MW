using Appusion.Core.Common.Base;
using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Services.Base;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Appusion.Core.Services.DietPlan
{
    public class DietPlanComponent : ComponentBase
    {
        private readonly IDietPlanRepository _dietPlanRepository;
        private readonly IUserDietPlanMapRepository _userDietPlanMapRepository;
        private readonly IMapper _mapper;
        private readonly CurrentUser _currentUser;
        public DietPlanComponent(IDietPlanRepository dietPlanRepository, 
                                 IMapper mapper, 
                                 IUserDietPlanMapRepository userDietPlanMapRepository,
                                 CurrentUser currentUser)
        {
            _dietPlanRepository = dietPlanRepository;
            _mapper = mapper;
            _userDietPlanMapRepository = userDietPlanMapRepository;
            _currentUser = currentUser;
        }

        public async Task<GenericServiceResponsePackage> SaveDietPlan(SaveDietPlanRequestPackage saveDietPlanRequestPackage)
        {
            var dietPlanEntity=  _mapper.Map<SaveDietPlanRequestPackage, DietPlanEntity>(saveDietPlanRequestPackage);
            // todo burada transaction başlatılmalı.
            {
                _dietPlanRepository.Insert(dietPlanEntity);
                if (dietPlanEntity.Id > 0)
                {
                    _userDietPlanMapRepository.Insert(new UserDietPlanMapEntity
                    {
                        PlanId = dietPlanEntity.Id,
                        UserId = _currentUser.Id
                    });
                }
            }
            return new GenericServiceResponsePackage { Success= true };
        }

        public async Task<GetDietPlanResponsePackage> GetDietPlan()
        {
            var dietPlanEntity = await _dietPlanRepository.GetActiveDietPlanEntity(_currentUser.Id);
            return _mapper.Map<DietPlanEntity, GetDietPlanResponsePackage>(dietPlanEntity);
        }
    }
}
