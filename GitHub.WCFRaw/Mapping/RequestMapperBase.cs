using System.ServiceModel.Channels;
using GitHub.WCFRaw.Api;

namespace GitHub.WCFRaw.Mapping
{
    /// <summary>
    /// Base for WCF Request Message Mappers
    /// </summary>
    /// <typeparam name="A">from</typeparam>
    abstract
    public class RequestMapperBase<A> : IMap<A, Message>
    {
        /// <summary>
        /// Sets version of the request SOAP message
        /// </summary>
        public MessageVersion MessageVersion { get; set; }

        /// <summary>
        /// Sets the SOAP action
        /// </summary>
        public string SoapAction { get; set; }

        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public abstract Message Map(A from);

        /// <summary>
        /// Ctor inits defaults for props
        /// </summary>
        protected RequestMapperBase()
        {
            // soap action does not really matter
            SoapAction = "";
            // msg version must match what server-side expects
            MessageVersion = MessageVersion.Soap11;
        }
    }
}
