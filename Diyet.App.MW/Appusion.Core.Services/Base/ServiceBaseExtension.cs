using Appusion.Core.BaseModels;
using Appusion.Core.Common.Utility;

namespace Appusion.Core.Services.Base
{
    /// <summary>
    /// ServiceBaseExtension
    /// </summary>
    public static class ServiceBaseExtension
    {
        public delegate void VoidParameterlessMethod();

        public delegate TReturn ParameterlessMethod<TReturn>();

        /// <summary>
        /// RunSafely
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="serviceBase"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static GenericServiceResult<TReturn> RunSafely<TReturn>(this ServiceBase serviceBase, ParameterlessMethod<TReturn> method)
        {
            GenericServiceResult<TReturn> result = new();
            try
            {
                result.Result = method();
                result.IsSuccessful = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception exception)
            {
                //return ExceptionHelper.DoExceptionRoutines(result, exception);
            }
            return result;
        }

        public static async Task<GenericServiceResult<TReturn>> RunSafelyAsync<TReturn> (this ServiceBase serviceBase, ParameterlessMethod<TReturn> method) where TReturn : class
         {
            GenericServiceResult<TReturn> result = new();
            try
            {
                result.Result = method();
                result.IsSuccessful = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception exception)
            {
                 return ExceptionHelper.DoExceptionRoutines(result, exception);
            }
            return result;
        }

        private static void Run(VoidParameterlessMethod method) 
        {
            method();
        }
    }
}