using System.ServiceModel.Channels;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using GitHub.WCFRaw.Api;

namespace GitHub.WCFRaw.Mapping
{
    /// <summary>
    /// Deserializes a response object that is XmlSerializable
    /// </summary>
    public class XmlSerializingResponseMapper<B>
        : ResponseMapperBase<B>
    {
        // response xml serializer to use
        private readonly XmlSerializer _xmlSerializer;

        /// <summary>
        /// Ctor that sets sensible defaults
        /// </summary>
        public XmlSerializingResponseMapper(string xmlNamespace = null)
        {
            _xmlSerializer // w/o the namespace 1st serialization is slow
                = xmlNamespace == null
                ? new XmlSerializer(typeof(B))
                : new XmlSerializer(typeof(B), xmlNamespace);
        }

        /// <summary>
        /// Marshalls a WCF MEssage to a Service Response
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public override B Map(Message from)
        {
            // this has the full soap envelope
            var xe = XElement.Parse(from.ToString());

            // check for soap fault
            var error =
                from fault in xe.Descendants(SoapFault)
                let code = fault.Descendants(FaultCode)
                let desc = fault.Descendants(FaultString)
                select new { code, desc };

            // if soap fault found, we cannot serialize to target
            if (error.Count() > 0)
                throw new ServiceException
                    ("[" + error.First().code + "] " + error.First().desc);

            // gets the root payload
            var q = from body in xe.Descendants(SoapBody)
                    let payload = body.FirstNode
                    select payload;

            // deserialize to B
            var xr = q.First().CreateReader();
            return (B)_xmlSerializer.Deserialize(xr);
        }
    }
}
