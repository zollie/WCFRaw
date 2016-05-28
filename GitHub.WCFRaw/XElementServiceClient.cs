using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Linq;
using GitHub.WCFRaw.Mapping;


namespace GitHub.WCFRaw
{
    /// <summary>
    /// A Service Client that uses raw 
    /// XML in XElement form
    /// </summary>
    public class XElementServiceClient
        : ServiceClientBase<XElement, XElement>
    {
        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="endpoint"></param>
        public XElementServiceClient
            (Binding binding, EndpointAddress endpoint)
                : base(binding, endpoint)
        {
            // message marshallers for raw XElement xml
            RequestMessageMapper = new XElementRequestMapper();
            ResponseMessageMapper = new XElementResponseMapper();
        }
    }
}
