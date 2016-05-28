using System.Collections.Generic;
using GitHub.ACORD;
using GitHub.WCFRaw.Examples.Acord.Api;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// Default impl of IAcordObjectFactory
    /// </summary>
    public class AcordObjectFactory : IAcordObjectFactory
    {
        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        public ITransRefGuidFactory TransRefGuidFactory { get; set; }

        /// <summary>
        /// Ctor that sets sensible defaults
        /// </summary>
        public AcordObjectFactory()
        {
            TransRefGuidFactory = new UuidTransRefGuidFactory();
        }

        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="transType"></param>
        /// <param name="transSubType"></param>
        /// <param name="withOlife"></param>
        /// <returns></returns>
        public TXLife NewTxLife
            (string transType, string transSubType = null, bool withOlife = true)
        {
            return new TXLife
            {
                TXLifeRequest = new List<TXLifeRequest>
                {
                    new TXLifeRequest
                    {
                        TransRefGUID = TransRefGuidFactory.NewTransRefGuid(),
                        TransType = new TransType { __tc = transType },
                        TransSubType =
                            transSubType != null
                            ? new TransSubType { __tc = transSubType }
                            : null,
                        OLifE = withOlife ? new OLifE() : null,
                    }
                }
            };
        }
    }
}
