using GitHub.ACORD;
using GitHub.WCFRaw;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// TXLife Extensions
    /// </summary>
    public static class TXLifeExtensions
    {
        /// <summary>
        /// Is this TXLife a request 
        /// </summary>
        /// <param name="txl"></param>
        /// <returns></returns>
        public static bool HasRequest(this TXLife txl)
        {
            return !txl.TXLifeRequest.IsEmpty();
        }

        /// <summary>
        /// Is this TXLife a response 
        /// </summary>
        /// <param name="txl"></param>
        /// <returns></returns>
        public static bool HasResponse(this TXLife txl)
        {
            return !txl.TXLifeResponse.IsEmpty();
        }
    }
}
