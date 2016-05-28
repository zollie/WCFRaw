using GitHub.ACORD;
using GitHub.WCFRaw.Api;
using GitHub.WCFRaw.Examples.Acord.Api;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// Base for Request to Acord Mappers
    /// </summary>
    /// <typeparam name="A"></typeparam>
    abstract
    public class RequestToAcordBase<A> : IMap<A, TXLife>
    {
        /// <summary>
        /// Acord Object Factory
        /// </summary>
        public IAcordObjectFactory AcordObjectFactory { get; set; }

        /// <summary>
        /// Ctor setting sensible defaults
        /// </summary>
        protected RequestToAcordBase()
        {
            AcordObjectFactory = new AcordObjectFactory();
        }

        /// <summary>
        /// <inherit-doc/>
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public abstract TXLife Map(A from);
    }
}
