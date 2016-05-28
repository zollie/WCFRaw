using System.ServiceModel.Channels;
using System.Xml.Linq;
using GitHub.WCFRaw.Api;

namespace GitHub.WCFRaw.Mapping
{
    /// <summary>
    /// Base for WCF Request Message Mappers
    /// </summary>
    /// <typeparam name="B">to</typeparam>
    abstract
    public class ResponseMapperBase<B>
        : IMap<Message, B>
    {
        // soap evelope namespace
        protected static readonly XNamespace SoapNs = "http://schemas.xmlsoap.org/soap/envelope/";
        // soap body node
        protected static readonly XName SoapBody = SoapNs + "Body";
        // soap fault node
        protected static readonly XName SoapFault = SoapNs + "Fault";
        // soap fault node
        protected static readonly XName FaultCode = SoapNs + "faultcode";
        // soap fault node
        protected static readonly XName FaultString = SoapNs + "faultstring";

        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public abstract B Map(Message from);
    }
}
