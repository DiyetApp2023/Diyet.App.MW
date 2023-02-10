﻿using System;
using Appusion.Core.Common.Entities.DietPlan;

namespace Appusion.Core.Common.Interface.Repositories
{
	public interface IUserDietPlanDetailRepository: IGenericRepository<UserDietPlanDetailEntity>
	{
		Task<UserDietPlanDetailEntity> GetUserDietPlanDetailEntity(long userId, long planId, int mealId);
	}
}

