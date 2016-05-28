using GitHub.ACORD;
using GitHub.WCFRaw.Mapping;

namespace GitHub.WCFRaw.Examples.Acord.Mapping
{
    /// <summary>
    /// ACORD Message Mapper
    /// </summary>
    public class AcordResponseMapper
        : XmlSerializingResponseMapper<TXLife>
    {
        /// <summary>
        /// Initializes base with ACORD Namespace
        /// </summary>
        public AcordResponseMapper()
            : base(Declarations.SchemaVersion)
        {
        }
    }
}
