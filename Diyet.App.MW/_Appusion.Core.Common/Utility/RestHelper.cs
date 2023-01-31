using RestSharp;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Newtonsoft.Json;
using RestSharp.Serializers.NewtonsoftJson;
using System.Text.Json;
using Appusion.Core.ExceptionBase;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// RestHelper
    /// </summary>
    public class RestHelper
    {
        private readonly RestClient _restClient;

        /// <summary>
        /// RestHelper
        /// </summary>
        /// <param name="restClient"></param>
        public RestHelper(RestClient restClient)
        {
            _restClient = restClient;
            _restClient.UseNewtonsoftJson(new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            });
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string resource) where T : class
        {
            RestRequest restRequest = new(resource, Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="paramDictionary"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string resource, Dictionary<string, string> paramDictionary, Dictionary<string, string> additionalHeaderParameters) where T : class
        {
            RestRequest restRequest = new(resource, Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            foreach (var param in paramDictionary)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }
            foreach (var additionalHeaderParameter in additionalHeaderParameters)
            {
                restRequest.AddHeader(additionalHeaderParameter.Key, additionalHeaderParameter.Value);
            }
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="resource"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T> Get<T, R>(string resource, R model) where T : class where R : class, new()
        {
            RestRequest restRequest = new(resource, Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddObject(model);
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<T> Put<T>(string resource) where T : class
        {
            RestRequest restRequest = new(resource, Method.Put);
            restRequest.AddHeader("Accept", "application/json");
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<T> Delete<T>(string resource) where T : class
        {
            RestRequest restRequest = new(resource, Method.Delete);
            restRequest.AddHeader("Accept", "application/json");
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<T> Post<T>(string resource, Dictionary<string, string> additionalHeaderParameters) where T : class
        {
            RestRequest restRequest = new(resource, Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            foreach (var additionalHeaderParameter in additionalHeaderParameters)
            {
                restRequest.AddHeader(additionalHeaderParameter.Key, additionalHeaderParameter.Value);
            }
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="resource"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T> Post<T, R>(string resource, R model, Dictionary<string, string> additionalHeaderParameters) where T : class where R : class, new()
        {
            RestRequest restRequest = new(resource, Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            foreach (var additionalHeaderParameter in additionalHeaderParameters)
            {
                restRequest.AddHeader(additionalHeaderParameter.Key, additionalHeaderParameter.Value);
            }
            restRequest.AddJsonBody(model);
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// Patch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="resource"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T> Patch<T, R>(string resource, R model) where T : class where R : class, new()
        {
            RestRequest restRequest = new(resource, Method.Patch);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(model);
            var content = await ExecuteService<T>(restRequest);
            return content;
        }

        /// <summary>
        /// ExecuteService
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="restRequest"></param>
        /// <returns></returns>
        private async Task<T> ExecuteService<T>(RestRequest restRequest)
        {
            T content = default(T);
            SslCertificateHelper.SetDefaultSslCertificateSettings();
            RestResponse executionResult;
            try
            {
                executionResult = await _restClient.ExecuteAsync(restRequest).ConfigureAwait(false);
                content = ContentToResult<T>(executionResult);
            }
            catch (Exception exception)
            {
                //todo logging.
                throw;
            }
            return content;
        }

        /// <summary>
        /// ContentToResult
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executionResult"></param>
        /// <returns></returns>
        private T ContentToResult<T>(RestResponse executionResult)
        {
            T content = default(T);

            if (executionResult.StatusCode == HttpStatusCode.OK)
            {
                if (executionResult.Request.RequestFormat == DataFormat.Json)
                {
                    content = JsonHelper.DeserializeObject<T>(executionResult.Content);
                }
            }
            else
            {
                if (executionResult.ContentHeaders != null && executionResult.ContentHeaders!.Any(c => c.Name == "Content-Type"
                                                                                                    && c.Value == "text/xml"))
                {
                    var xmlResult = XmlHelper.GetParsedXmlContent(executionResult.Content);
                    throw new ApiException(executionResult.ErrorException?.Message, xmlResult, executionResult.StatusCode);
                }
                else if (executionResult.Request.RequestFormat == DataFormat.Json)
                {
                    throw new ApiException(executionResult.ErrorException?.Message, executionResult.Content, executionResult.StatusCode);
                }
            }
            return content;
        }
    }
}