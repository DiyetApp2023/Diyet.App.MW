using Microsoft.AspNetCore.Http;
using Appusion.Core.BaseModels;
using Appusion.Core.ExceptionBase;
using Appusion.Core.Common.Utility;
using RestSharp;
using System;
using Appusion.Core.ServiceBase;

namespace Appusion.Core.Services.Base
{
    /// <summary>
    /// ServiceCaller
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    public class ServiceCaller : IServiceCaller
    {
        private readonly RestHelper _restHelper;
        private readonly RestClient _restClient;
        private readonly HttpClient _httpClient;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// ServiceCaller
        /// </summary>
        /// <param name="restHelper"></param>
        public ServiceCaller(RestHelper restHelper,
                             RestClient restClient,
                             IServiceProvider serviceProvider,
                             HttpClient httpClient)
        {
            _restHelper = restHelper;
            _restClient = restClient;
            _serviceProvider = serviceProvider;
            _httpClient = httpClient;
        }

        /// <summary>
        /// RunDeleteService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunDeleteService<T>(string serviceUrl) where T : class
        {
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                var result = await _restHelper.Delete<GenericServiceResult<T>>(serviceUrl);
                return result;
            }
            catch (Exception exception)
            {
                // todo logging.
                throw;
            }
        }

        /// <summary>
        /// RunGetService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunGetService<T, R>(string serviceUrl, R requestModel)
            where T : class
            where R : class, new()
        {
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                var result = await _restHelper.Get<GenericServiceResult<T>, R>(serviceUrl, requestModel);
                return result;
            }
            catch (Exception exception)
            {
                // todo logging.
                throw;
            }
        }

        /// <summary>
        /// RunGetService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="paramDictionary"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunGetService<T, R>(string serviceUrl, Dictionary<string, string> paramDictionary, Dictionary<string, string> additionalHeaderParameters)
            where T : class
            where R : class, new()
        {
            GenericServiceResult<T> result = new GenericServiceResult<T>();
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                result.Result = await _restHelper.Get<T>(serviceUrl, paramDictionary, additionalHeaderParameters);
                result.IsSuccessful = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception exception)
            {
                return ExceptionHelper.DoExceptionRoutines(result, exception);
            }

            return result;

        }

        /// <summary>
        /// RunGetService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunGetService<T>(string serviceUrl) where T : class
        {
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                RestRequest r = new RestRequest();
                var result = await _restHelper.Get<GenericServiceResult<T>>(serviceUrl);
                return result;
            }
            catch (Exception exception)
            {
                // todo logging.
                throw;
            }
        }

        /// <summary>
        /// RunPatchService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunPatchService<T, R>(string serviceUrl, R requestModel)
            where T : class
            where R : class, new()
        {
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                var result = await _restHelper.Patch<GenericServiceResult<T>, R>(serviceUrl, requestModel);
                return result;
            }
            catch (Exception exception)
            {
                // todo logging.
                throw;
            }
        }

        /// <summary>
        /// RunPostService
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult> RunPostService<R>(string serviceUrl, R requestModel, Dictionary<string, string> additionalHeaderParameters) where R : class, new()
        {
            GenericServiceResult result = new();
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                result = await _restHelper.Post<GenericServiceResult, R>(serviceUrl, requestModel, additionalHeaderParameters);
                result.IsSuccessful = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception exception)
            {
                return ExceptionHelper.DoExceptionRoutines(result, exception);
            }
            return result;
        }

        /// <summary>
        /// RunPostServiceByParamater
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunPostServiceByParamater<T, R>(string serviceUrl, R requestModel, Dictionary<string, string> additionalHeaderParameters)
            where T : class
            where R : class, new()
        {
            GenericServiceResult<T> result = new GenericServiceResult<T>();
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                result.Result = await _restHelper.Post<T, R>(serviceUrl, requestModel, additionalHeaderParameters);
                result.IsSuccessful = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception exception)
            {
                return ExceptionHelper.DoExceptionRoutines(result, exception);
            }
            return result;
        }

        /// <summary>
        /// RunPostServiceByParamaterless
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunPostServiceByParamaterless<T>(string serviceUrl, Dictionary<string, string> additionalHeaderParameters) where T : class
        {
            GenericServiceResult<T> result = new GenericServiceResult<T>();
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                result.Result = await _restHelper.Post<T>(serviceUrl, additionalHeaderParameters);
                result.IsSuccessful = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception exception)
            {
                return ExceptionHelper.DoExceptionRoutines(result, exception);
            }
            return result;
        }

        /// <summary>
        /// RunPutService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceUrl"></param>
        /// <returns></returns>
        public async Task<GenericServiceResult<T>> RunPutService<T>(string serviceUrl) where T : class
        {
            try
            {
                TlsHelper.SetDefaultTlsSettings();
                var result = await _restHelper.Put<GenericServiceResult<T>>(serviceUrl);
                return result;
            }
            catch (Exception exception)
            {
                // todo logging.
                throw;
            }
        }
    }
}