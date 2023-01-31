using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// JsonHelper
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// DeserializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string content)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
            var result = JsonConvert.DeserializeObject<T>(content, jsonSerializerSettings);
            return result;
        }

        /// <summary>
        /// GetDefaultJsonHeaderParameters
        /// </summary>
        public static Dictionary<string,string> GetDefaultJsonHeaderParameters
        {
            get
            {
                var defaultJsonHeaderParameters = new Dictionary<string, string>()
                {
                    { "Accept",   "application/json" },
                    { "Content-Type",   "application/json" }
                };
                return defaultJsonHeaderParameters;
            }
        }
    }
}