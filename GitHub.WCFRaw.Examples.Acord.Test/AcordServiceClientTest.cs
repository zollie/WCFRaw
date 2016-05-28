using System;
using System.IO;
using System.ServiceModel;
using System.Xml.Serialization;
using NUnit.Framework;
using GitHub.ACORD;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// AcordServiceClient Unit Test
    /// </summary>
    [TestFixture]
    public class AcordServiceClientTest
    {
        private const string XmlFileName = "./AcordExample.xml";
        private TXLife _msg;
        private AcordServiceClient _client;

        /// <summary>
        /// Setup
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // this is slow
            var tr = new StreamReader(XmlFileName);
            var xs = new XmlSerializer(typeof(TXLife), Declarations.SchemaVersion);
            _msg = (TXLife)xs.Deserialize(tr);
            _client = new AcordServiceClient
                (new BasicHttpBinding(), new EndpointAddress("http://someserver:80/life"));
        }

        /// <summary>
        /// Teardown
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _msg = null;
            _client = null;
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestObservable()
        {
            _client.AsObservable(_msg).Subscribe
            (
                xelm => Console.WriteLine("Response was " + xelm),
                e => Console.WriteLine("Exception " + e),
                () => Console.WriteLine("Done")
            );
        }

        [Test]
        public void TestSync()
        {
            var resp = _client.Service(_msg);
            Console.WriteLine(resp.ToString());
        }
    }
}
