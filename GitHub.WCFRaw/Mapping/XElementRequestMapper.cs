using System.ServiceModel.Channels;
using System.Xml.Linq;

namespace GitHub.WCFRaw.Mapping
{
    /// <summary>
    /// Message Marshaller for raw 
    /// XML in XElement form
    /// </summary>
    public class XElementRequestMapper
        : RequestMapperBase<XElement>
    {
        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public override Message Map(XElement from)
        {
            return Message.CreateMessage
                (MessageVersion, SoapAction, from.CreateReader());
        }
    }
}
