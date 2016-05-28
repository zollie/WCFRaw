using GitHub.ACORD;
using GitHub.WCFRaw.Mapping;

namespace GitHub.WCFRaw.Examples.Acord.Mapping
{
    /// <summary>
    /// ACORD MessageMarshaller
    /// </summary>
    public class AcordRequestMapper
        : XmlSerializingRequestMapper<TXLife>
    {
        /// <summary>
        /// Initializes base with ACORD Namespace
        /// </summary>
        public AcordRequestMapper()
            : base(Declarations.SchemaVersion)
        {
        }
    }
}
