using Appusion.Core.BaseModels;
using Appusion.Core.Common.Base;
using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Common.ResponseModels.User;
using Appusion.Core.ExceptionBase;
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
        private readonly IUserDietPlanDetailRepository _userDietPlanDetailRepository;
        private readonly IUserDietPlanMealDetailProductMapEntityRepository _userDietPlanMealDetailProductMapEntityRepository;
        private readonly IUserDailyActivityEntityRepository _userDailyActivityEntityRepository;
        public DietPlanComponent(IDietPlanRepository dietPlanRepository, 
                                 IMapper mapper, 
                                 IUserDietPlanMapRepository userDietPlanMapRepository,
                                 CurrentUser currentUser,
                                 IUserDietPlanDetailRepository userDietPlanDetailRepository,
                                 IUserDietPlanMealDetailProductMapEntityRepository userDietPlanMealDetailProductMapEntityRepository,
                                 IUserDailyActivityEntityRepository userDailyActivityEntityRepository)
        {
            _dietPlanRepository = dietPlanRepository;
            _mapper = mapper;
            _userDietPlanMapRepository = userDietPlanMapRepository;
            _currentUser = currentUser;
            _userDietPlanDetailRepository = userDietPlanDetailRepository;
            _userDietPlanMealDetailProductMapEntityRepository = userDietPlanMealDetailProductMapEntityRepository;
            _userDailyActivityEntityRepository = userDailyActivityEntityRepository;
        }

        public async Task<SaveDietPlanResponsePackage> SaveDietPlan(SaveDietPlanRequestPackage saveDietPlanRequestPackage)
        {
            long planId = 0;
            if (saveDietPlanRequestPackage != null)
            {
                var dietPlanEntity = _mapper.Map<SaveDietPlanRequestPackage, DietPlanEntity>(saveDietPlanRequestPackage);
                // todo burada transaction başlatılmalı.
                if (dietPlanEntity != null)
                {
                    if (dietPlanEntity.Id <= 0)
                    {
                        await _dietPlanRepository.Insert(dietPlanEntity);
                        await _userDietPlanMapRepository.Insert(new UserDietPlanMapEntity
                        {
                            PlanId = dietPlanEntity.Id,
                            UserId = _currentUser.Id
                        });
                    }
                    else
                    {
                        await _dietPlanRepository.Update(dietPlanEntity);
                    }
                    planId = dietPlanEntity.Id;
                }
            }
            return new SaveDietPlanResponsePackage { PlanId = planId };
        }

        public async Task<GetDietPlanResponsePackage> GetDietPlan()
        {
            if (_currentUser==null)
            {
                throw new ApiException("Sistemde kayıtlı kullanıcı bulunamamıştır.");
            }
            var dietPlanEntity = await _dietPlanRepository.GetActiveDietPlanEntity(_currentUser.Id);
            var result = _mapper.Map<DietPlanEntity, GetDietPlanResponsePackage>(dietPlanEntity);
            return result;
        }

        public async Task<GetUserDietMealPlanResponsePackage> GetUserDietMealPlan()
        {
            if (_currentUser == null)
            {
                throw new ApiException("Sistemde kayıtlı kullanıcı bulunamamıştır.");
            }
            var result = await _dietPlanRepository.GetActiveUserDietMealPlan(_currentUser.Id);
            return result;
        }

        public async Task<GenericServiceResponsePackage> SaveUserDietMealPlan(SaveUserDietMealPlanRequestPackage saveUserDietMealPlanRequestPackage)
        {
            var success = false;
            if (saveUserDietMealPlanRequestPackage != null)
            {
                var userDietPlanDetailEntity = _mapper.Map<SaveUserDietMealPlanRequestPackage, UserDietPlanDetailEntity>(saveUserDietMealPlanRequestPackage);
                // todo burada transaction başlatılmalı.
                if (userDietPlanDetailEntity != null)
                {
                    if (userDietPlanDetailEntity.Id <= 0)
                    {
                        await _userDietPlanDetailRepository.Insert(userDietPlanDetailEntity);
                    }
                    else
                    {
                        await _userDietPlanDetailRepository.Update(userDietPlanDetailEntity);
                    }

                    var userDietPlanMealDetailProductMapEntityList = _mapper.Map<List<UserDietPlanMealDetailProductMapRequestPackage>, List<UserDietPlanMealDetailProductMapEntity>>(saveUserDietMealPlanRequestPackage.ProductDetails);
                    if (userDietPlanMealDetailProductMapEntityList != null)
                    {
                         userDietPlanMealDetailProductMapEntityList.ForEach(userDietPlanMealDetailProductMapEntity =>
                        {
                             userDietPlanMealDetailProductMapEntity.UserDietPlanDetailId = userDietPlanDetailEntity.Id;
                            if (userDietPlanMealDetailProductMapEntity.Id<=0)
                            {
                                 _userDietPlanMealDetailProductMapEntityRepository.Insert(userDietPlanMealDetailProductMapEntity);
                            }
                            else
                            {
                                 _userDietPlanMealDetailProductMapEntityRepository.Update(userDietPlanMealDetailProductMapEntity);

                            }
                        });
                        success = true;
                    }
                }
            }

            return new GenericServiceResponsePackage { Success = success };
        }

        public async Task<GenericServiceResponsePackage> SaveUserDailyActivity(SaveUserDailyActivityRequestPackage saveUserDailyActivityRequestPackage)
        {
            var success = false;
            if (_currentUser == null)
            {
                throw new ApiException("Sistemde kayıtlı kullanıcı bulunamamıştır.");
            }
            if (saveUserDailyActivityRequestPackage!=null)
            {
                var userDailyActivityEntity = await _userDailyActivityEntityRepository.GetUserDailyActivityEntity(_currentUser.Id, saveUserDailyActivityRequestPackage.ActivityType);
                if (userDailyActivityEntity != null)
                {
                    userDailyActivityEntity.ActivityValue = saveUserDailyActivityRequestPackage.ActivityValue;
                    await _userDailyActivityEntityRepository.Update(userDailyActivityEntity);
                }
                else
                {
                    await _userDailyActivityEntityRepository.Insert(new Common.Entities.User.UserDailyActivityEntity
                    {
                        UserId = _currentUser.Id,
                        ActivityType = saveUserDailyActivityRequestPackage.ActivityType,
                        ActivityValue = saveUserDailyActivityRequestPackage.ActivityValue
                    });
                }
                success = true;
            }
            return new GenericServiceResponsePackage { Success = success };
        }

        public async Task<List<GetUserDailyActivityResponsePackage>> GetUserDailyActivityList(DateTime activityDate)
        {
            if (_currentUser == null)
            {
                throw new ApiException("Sistemde kayıtlı kullanıcı bulunamamıştır.");
            }
            if (activityDate==null || activityDate==DateTime.MinValue || activityDate==DateTime.MaxValue)
            {
                 activityDate = DateTime.UtcNow.Date;
            }
           
            var userDailyActivityEntity = await _userDailyActivityEntityRepository.GetUserDailyActivityList(_currentUser.Id, activityDate);
            return userDailyActivityEntity;
        }
    }
}