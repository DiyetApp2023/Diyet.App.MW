using Appusion.Core.BaseModels;

namespace Appusion.Core.ServiceBase
{
    /// <summary>
    /// IServiceCaller
    /// </summary>
    public interface IServiceCaller
    {
        /// <summary>
        /// RunPostServiceByParamater
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunPostServiceByParamater<T,R>(string serviceUrl,R requestModel, Dictionary<string, string> additionalHeaderParameters=null) where T: class where R: class , new();

        /// <summary>
        /// RunPostServiceByParamaterless
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunPostServiceByParamaterless<T>(string serviceUrl, Dictionary<string, string> additionalHeaderParameters = null) where T : class;

        /// <summary>
        /// RunPostService
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<GenericServiceResult> RunPostService<R>(string serviceUrl, R requestModel, Dictionary<string, string> additionalHeaderParameters = null)  where R : class, new();

        /// <summary>
        /// RunGetService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunGetService<T, R>(string serviceUrl, R requestModel) where T : class where R : class, new();

        /// <summary>
        /// RunGetService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="paramDictionary"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunGetService<T, R>(string serviceUrl, Dictionary<string,string> paramDictionary, Dictionary<string, string> additionalHeaderParameters) where T : class where R : class, new();

        /// <summary>
        /// RunGetService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunGetService<T>(string serviceUrl) where T : class;

        /// <summary>
        /// RunPatchService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunPatchService<T, R>(string serviceUrl, R requestModel) where T : class where R : class, new();

        /// <summary>
        /// RunPutService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunPutService<T>(string serviceUrl) where T : class;

        /// <summary>
        /// RunDeleteService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        Task<GenericServiceResult<T>> RunDeleteService<T>(string serviceUrl) where T : class;
    }
}