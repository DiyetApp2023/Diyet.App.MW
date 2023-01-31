using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.ExceptionBase
{
    /// <summary>
    /// MiddlewareException
    /// </summary>
    public class MiddlewareException : Exception
    {
        /// <summary>
        /// ExceptionErrorMessage
        /// </summary>
        public string ExceptionErrorMessage { get; set; }

        /// <summary>
        /// HttpStatusCode
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="message"></param>
        public MiddlewareException(string exceptionErrorMessage)
        {
            ExceptionErrorMessage = exceptionErrorMessage;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public MiddlewareException(string exceptionErrorMessage, HttpStatusCode httpStatusCode)
        {
            ExceptionErrorMessage = exceptionErrorMessage;
            HttpStatusCode = httpStatusCode;
        }
    }
}
