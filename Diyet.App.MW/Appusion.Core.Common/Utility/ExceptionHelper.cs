using Appusion.Core.BaseModels;
using Appusion.Core.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// ExceptionHelper
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// DoExceptionRoutines
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static GenericServiceResult<T> DoExceptionRoutines<T>(GenericServiceResult<T> result, Exception exception) where T : class
        {
            result.Result = null;
            result.IsSuccessful = false;
            var apiException = (exception as ApiException);
            if (apiException==null)
            {
               apiException = (exception.InnerException as ApiException);
            } 
            var middlewareException = exception as MiddlewareException;
            if (apiException==null && middlewareException == null)
            {
                middlewareException = (exception.InnerException as MiddlewareException);
            }
            if (apiException != null)
            {
                result.ExceptionErrorMessage = apiException.ExceptionErrorMessage;
                result.ExceptionContentMessage = apiException.ExceptionContentMessage;
                result.HttpStatusCode = apiException.HttpStatusCode;
            }
            else if (middlewareException != null)
            {
                result.ExceptionErrorMessage = middlewareException.ExceptionErrorMessage;
                result.HttpStatusCode = middlewareException.HttpStatusCode;
            }
            else
            {
                result.ExceptionErrorMessage = exception.Message;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return result;
        }

        /// <summary>
        /// DoExceptionRoutines
        /// </summary>
        /// <param name="result"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static GenericServiceResult DoExceptionRoutines(GenericServiceResult result, Exception exception)
        {
            var apiException = exception as ApiException;
            var middlewareException = exception as MiddlewareException;
            result.IsSuccessful = false;
            if (apiException != null)
            {
                result.ExceptionErrorMessage = apiException.ExceptionErrorMessage;
                result.ExceptionContentMessage = apiException.ExceptionContentMessage;
                result.HttpStatusCode = apiException.HttpStatusCode;
            }
            else if (middlewareException != null)
            {
                result.ExceptionErrorMessage = middlewareException.ExceptionErrorMessage;
                result.HttpStatusCode = middlewareException.HttpStatusCode;
            }
            else
            {
                result.ExceptionErrorMessage = exception.Message;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return result;
        }
    }
}
