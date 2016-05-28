using System;

namespace GitHub.WCFRaw.Api
{
    /// <summary>
    /// A General Service Framework Exception
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        public ServiceException()
        {
        }

        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        public ServiceException(string message) : base(message)
        {
        }

        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        public ServiceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}