using System;
using GitHub.WCFRaw.Examples.Acord.Api;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// Default impl of ITransRefGuidFactory
    /// </summary>
    public class UuidTransRefGuidFactory
        : ITransRefGuidFactory
    {
        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <returns></returns>
        public string NewTransRefGuid()
        {
            return "ACORD-" + Guid.NewGuid();
        }
    }
}
