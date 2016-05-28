
using GitHub.ACORD;

namespace GitHub.WCFRaw.Examples.Acord.Api
{
    /// <summary>
    /// Defines an Acord Object Factory
    /// </summary>
    public interface IAcordObjectFactory
    {
        /// <summary>
        /// The Guid factory
        /// </summary>
        ITransRefGuidFactory TransRefGuidFactory { get; set; }

        /// <summary>
        /// New TxLife
        /// </summary>
        /// <param name="transType"></param>
        /// <param name="transSubType"></param>
        /// <param name="withOlife"></param>
        /// <returns></returns>
        TXLife NewTxLife(string transType, string transSubType = null, bool withOlife = true);
    }
}
