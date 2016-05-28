using System.Linq;
using System.ServiceModel.Channels;
using System.Xml.Linq;
using GitHub.WCFRaw.Api;

namespace GitHub.WCFRaw.Mapping
{
    /// <summary>
    /// Message Mapper for raw 
    /// XML in XElement form
    /// </summary>
    public class XElementResponseMapper 
        : ResponseMapperBase<XElement>
    {
        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
       public override XElement Map(Message msg)
        {
            var xe = XElement.Parse(msg.ToString());

            var error =
                from fault in xe.Descendants(SoapFault)
                let code = fault.Descendants(FaultCode)
                let desc = fault.Descendants(FaultString)
                select new {code, desc};

            if (error.Count() > 0)
                throw new ServiceException
                    ("[" + error.First().code + "] " + error.First().desc);

            return xe;
        }
    }
}
