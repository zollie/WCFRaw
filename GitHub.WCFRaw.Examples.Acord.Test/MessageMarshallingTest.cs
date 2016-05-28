using System.Diagnostics;
using System.IO;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using GitHub.ACORD;

namespace GitHub.WCFRaw.Examples.Acord.Test
{
    /// <summary>
    /// Test Marshalling Wcf Messages
    /// </summary>
    [TestFixture]
    public class MessageMarshallingTest
    {
        // internal serializer
        private const string XmlFileName = "./AcordExample.xml";
        private readonly XmlSerializer _xmlSerializer
            = new XmlSerializer(typeof(TXLife), Declarations.SchemaVersion);
        private TXLife _request;

        /// <summary>
        /// SetUp Fixture
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var sr = new StreamReader(XmlFileName);
            _request = (TXLife)_xmlSerializer.Deserialize(sr);
        }

        /// <summary>
        /// TearDown Fixture
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _request = null;
        }

        /// <summary>
        /// Test Marshalling Requesy
        /// </summary>
        [Test]
        public void TestMarshallRequest()
        {
            var sw = new StringWriter();
            _xmlSerializer.Serialize(sw, _request);
            Debug.WriteLine("sw is " + sw);

            var xr = XmlReader.Create(new StringReader(sw.ToString()));

            var msg = Message.CreateMessage(MessageVersion.Soap11, "", xr);
            Debug.WriteLine("msg is " + msg);

        }
    }
}
