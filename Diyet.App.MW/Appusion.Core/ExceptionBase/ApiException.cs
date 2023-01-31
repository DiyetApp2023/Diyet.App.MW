using Appusion.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.ExceptionBase
{
    /// <summary>
    /// ApiException
    /// </summary>
    public class ApiException : Exception 
    {
        /// <summary>
        /// ExceptionContentMessage
        /// </summary>
        public string ExceptionContentMessage { get; set; }

        /// <summary>
        /// HttpStatusCode
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// ExceptionErrorMessage
        /// </summary>
        public string ExceptionErrorMessage { get; set; }

        /// <summary>
        /// ApiException
        /// </summary>
        /// <param name="message"></param>
        public ApiException(string exceptionContentMessage)
        {
            ExceptionContentMessage = exceptionContentMessage;
        }
      
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public ApiException(string exceptionContentMessage, HttpStatusCode httpStatusCode)
        {
            ExceptionContentMessage = exceptionContentMessage;
            HttpStatusCode = httpStatusCode;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public ApiException(string exceptionErrorMessage, string exceptionContentMessage, HttpStatusCode httpStatusCode)
        {
            ExceptionErrorMessage = exceptionErrorMessage;
            ExceptionContentMessage = exceptionContentMessage;
            HttpStatusCode = httpStatusCode;
        }

        /// <summary>
        /// genericServiceResult
        /// </summary>
        /// <param name="genericServiceResult"></param>
        public ApiException(GenericServiceResult genericServiceResult)
        {
            ExceptionErrorMessage = genericServiceResult.ExceptionErrorMessage;
            ExceptionContentMessage = genericServiceResult.ExceptionContentMessage;
            HttpStatusCode = genericServiceResult.HttpStatusCode;
        }
    }
}