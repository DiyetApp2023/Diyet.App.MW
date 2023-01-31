using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Enums
{
    /// <summary>
    /// ExceptionType
    /// </summary>
    public enum ExceptionType
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// UnknownException
        /// </summary>
        UnknownException = 1,

        /// <summary>
        /// ErrorException
        /// </summary>
        ErrorException = 2,

        /// <summary>
        /// ValidationException
        /// </summary>
        ValidationException = 3,

        /// <summary>
        /// CommunicationException
        /// </summary>
        CommunicationException = 4,

        /// <summary>
        /// AuthorizationException
        /// </summary>
        AuthorizationException = 5,

        /// <summary>
        /// SessionInvalidException
        /// </summary>
        SessionInvalidException = 6,

        /// <summary>
        /// IntegrationException
        /// </summary>
        IntegrationException = 7
    }
}