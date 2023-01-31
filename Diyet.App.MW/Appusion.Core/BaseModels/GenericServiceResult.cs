using Appusion.Core.Enums;
using System.Net;

namespace Appusion.Core.BaseModels
{
    /// <summary>
    /// GenericServiceResult
    /// </summary>
    [Serializable]
    public class GenericServiceResult
    {
        /// <summary>
        /// IsSuccessful
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// ExceptionType
        /// </summary>
        public ExceptionType ExceptionType { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// HttpStatusCode
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }


        /// <summary>
        /// ExceptionErrorMessage
        /// </summary>
        public string ExceptionErrorMessage { get; set; }


        /// <summary>
        /// ExceptionContentMessage
        /// </summary>
        public string ExceptionContentMessage { get; set; }
    }

    /// <summary>
    /// GenericServiceResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class GenericServiceResult<T> : GenericServiceResult
    {
        public T Result { get; set; }
    }
}
