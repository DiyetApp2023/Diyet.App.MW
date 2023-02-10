using Appusion.Core.BaseModels;
using Appusion.Core.Common.Entities.Meal;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.ResponseModels.Meal;
using Appusion.Core.Services.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Services.Meal
{
    public class MealComponent : ComponentBase
    {
        private readonly IMealEntityRepository _mealEntityRepository;
        private readonly IMapper _mapper;
        public MealComponent(IMealEntityRepository mealEntityRepository, IMapper mapper) 
        {
            _mealEntityRepository = mealEntityRepository;
            _mapper= mapper;
        }

        public async Task<List<GetMealListResponsePackage>> GetMealList()
        {
           var meailEntityList =  await _mealEntityRepository.GetMealEntityList();
           return _mapper.Map<List<MealEntity>, List<GetMealListResponsePackage>>(meailEntityList);
        }

        public async Task<List<GetDefaultScheduledMealListResponsePackage>> GetDefaultScheduledMealList()
        {
            var meailEntityList = await _mealEntityRepository.GetDefaultScheduledMealList();
            return _mapper.Map<List<MealEntity>, List<GetDefaultScheduledMealListResponsePackage>>(meailEntityList);
        }
    }
}