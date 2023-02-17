using Appusion.Core.BaseModels;
using Appusion.Core.Common.Base;
using Appusion.Core.Common.Entities.DietPlan;
using Appusion.Core.Common.Entities.ExercisePlan;
using Appusion.Core.Common.Implementation.Repositories;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.RequestModels.DietPlan;
using Appusion.Core.Common.RequestModels.ExercisePlan;
using Appusion.Core.Common.ResponseModels.DietPlan;
using Appusion.Core.Common.ResponseModels.ExercisePlan;
using Appusion.Core.ExceptionBase;
using Appusion.Core.Services.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.ExercisePlan
{
    public class ExercisePlanComponent : ComponentBase
    {
        private readonly IMapper _mapper;
        private readonly CurrentUser _currentUser;
        private readonly IExercisePlanRepository _exercisePlanRepository;
        private readonly IUserExercisePlanMapRepository _userExercisePlanMapRepository;
        private readonly IUserExerciseRepository _userExerciseRepository;
        
        public ExercisePlanComponent(IMapper mapper, 
                                    CurrentUser currentUser, 
                                    IExercisePlanRepository exercisePlanRepository, 
                                    IUserExercisePlanMapRepository userExercisePlanMapRepository,
                                    IUserExerciseRepository userExerciseRepository)
        {
            _mapper = mapper;
            _currentUser = currentUser;
            _exercisePlanRepository= exercisePlanRepository;
            _userExercisePlanMapRepository = userExercisePlanMapRepository;
            _userExerciseRepository = userExerciseRepository;
        }

        public async Task<SaveExercisePlanRequestPackage> GetExercisePlan()
        {
            if (_currentUser == null)
            {
                throw new ApiException("Sistemde kayıtlı kullanıcı bulunamamıştır.");
            }
            var exercisePlanEntity = await _exercisePlanRepository.GetActiveExercisePlanEntity(_currentUser.Id);
            var result = _mapper.Map<ExercisePlanEntity, SaveExercisePlanRequestPackage>(exercisePlanEntity);
            return result;
        }

        public async Task<SaveExercisePlanResponsePackage> SaveExercisePlan(SaveExercisePlanRequestPackage saveExercisePlanRequestPackage)
        {
            long planId = 0;
            if (saveExercisePlanRequestPackage != null)
            {
                var exercisePlanEntity = _mapper.Map<SaveExercisePlanRequestPackage, ExercisePlanEntity>(saveExercisePlanRequestPackage);
                // todo burada transaction başlatılmalı.
                if (exercisePlanEntity != null)
                {
                    if (exercisePlanEntity.Id <= 0)
                    {
                        await _exercisePlanRepository.Insert(exercisePlanEntity);
                        await _userExercisePlanMapRepository.Insert(new UserExercisePlanMapEntity
                        {
                            ExercisePlanId = exercisePlanEntity.Id,
                            UserId = _currentUser.Id
                        });
                    }
                    else
                    {
                        await _exercisePlanRepository.Update(exercisePlanEntity);
                    }
                    planId = exercisePlanEntity.Id;
                }
            }
            return new SaveExercisePlanResponsePackage { PlanId = planId };
        }

        public async Task<List<GetAllExerciseListResponsePackage>> GetAllExerciseList()
        {
            var exerciseEntityList = await _exercisePlanRepository.GetAllExerciseList();
            return _mapper.Map<List<ExerciseDefinitionEntity>, List<GetAllExerciseListResponsePackage>>(exerciseEntityList);
        }

        public async Task<List<GetAllExerciseListResponsePackage>> GetSearchedExerciseList(GetSearchedExerciseListRequestPackage getSearchedExerciseListRequestPackage)
        {
            var searchedExerciseEntityList = await _exercisePlanRepository.GetSearchedExerciseList(getSearchedExerciseListRequestPackage.SearchedExercise);
            return _mapper.Map<List<ExerciseDefinitionEntity>, List<GetAllExerciseListResponsePackage>>(searchedExerciseEntityList);
        }

        public async Task SaveUserExercises(SaveUserExercisesRequestPackage saveUserExercisesRequests)
        {
            var userExercisePlanMapEntity = await _userExercisePlanMapRepository.GetUserExercisePlanMapEntity(_currentUser.Id);
            var userExerciseEntities = _mapper.Map<List<UserExerciseInfo>, List<UserExerciseEntity>>(saveUserExercisesRequests.UserExerciseInfoList);
            foreach (var item in userExerciseEntities)
            {
                item.UserExercisePlanMapId =userExercisePlanMapEntity.Id;
                await _userExerciseRepository.Insert(item);
            }
        }
    }
}
