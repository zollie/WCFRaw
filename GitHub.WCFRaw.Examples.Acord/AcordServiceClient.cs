using System.ServiceModel;
using System.ServiceModel.Channels;
using GitHub.ACORD;
using GitHub.WCFRaw;
using GitHub.WCFRaw.Examples.Acord.Mapping;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// A WCF Service Client that uses XML bound
    /// to the ACORD object model
    /// </summary>
    public class AcordServiceClient
        : ServiceClientBase<TXLife, TXLife>
    {
        /// <summary>
        /// Ctor for base
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="endpoint"></param>
        public AcordServiceClient
            (Binding binding, EndpointAddress endpoint)
                : base(binding, endpoint)
        {
            RequestMessageMapper = new AcordRequestMapper();
            ResponseMessageMapper = new AcordResponseMapper();
        }
    }
}
