using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.RequestModels.ExercisePlan
{
    public class SaveUserExercisesRequestPackage
    {
        public List<UserExerciseInfo> UserExerciseInfoList { get; set; }
    }

    public class UserExerciseInfo
    {
        public long ExerciseId { get; set; }

        public double Quantity { get; set; }

        public int Iteration { get; set; }
    }
}
