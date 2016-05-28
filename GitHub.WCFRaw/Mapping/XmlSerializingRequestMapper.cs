using System.IO;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;

namespace GitHub.WCFRaw.Mapping
{
    /// <summary>
    /// Serializes a request object that is XmlSerializable
    /// </summary>
    public class XmlSerializingRequestMapper<A>
        : RequestMapperBase<A>
    {
        // request xml serializer to use
        private readonly XmlSerializer _xmlSerializer;

        /// <summary>
        /// Ctor that sets sensible defaults
        /// </summary>
        public XmlSerializingRequestMapper(string xmlNamespace = null)
        {
            _xmlSerializer // w/o the namespace 1st serialization is slow
                = xmlNamespace == null
                ? new XmlSerializer(typeof(A))
                : new XmlSerializer(typeof(A), xmlNamespace);
        }

        /// <summary>
        /// Marshalls a Service Request to a WCF Message
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public override Message Map(A from)
        {
            // serialize request
            var sw = new StringWriter();
            _xmlSerializer.Serialize(sw, from);

            // read serialized into Message
            var xr = XmlReader.Create(new StringReader(sw.ToString()));
            return Message.CreateMessage(MessageVersion, SoapAction, xr);
        }
    }
}
