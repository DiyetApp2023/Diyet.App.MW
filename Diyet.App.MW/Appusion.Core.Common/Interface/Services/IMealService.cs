using Appusion.Core.BaseModels;
using Appusion.Core.Common.RequestModels.User;
using Appusion.Core.Common.ResponseModels.General;
using Appusion.Core.Common.ResponseModels.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Interface.Services
{
    public interface IMealService
    {
        Task<GenericServiceResult<List<GetDefaultScheduledMealListResponsePackage>>> GetDefaultScheduledMealList();
        Task<GenericServiceResult<List<GetMealListResponsePackage>>> GetMealList();
    }
}
