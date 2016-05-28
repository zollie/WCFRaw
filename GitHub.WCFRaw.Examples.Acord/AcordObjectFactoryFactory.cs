using GitHub.WCFRaw.Examples.Acord.Api;

namespace GitHub.WCFRaw.Examples.Acord
{
    /// <summary>
    /// Simple Factory for IAcordObjectFactory
    /// </summary>
    public static class AcordObjectFactoryFactory
    {
        private static readonly IAcordObjectFactory
            Factory = new AcordObjectFactory();

        /// <summary>
        /// Get an IAcordObjectFactory
        /// </summary>
        /// <returns></returns>
        public static IAcordObjectFactory GetAcordObjectFactory()
        {
            return Factory;
        }
    }
}
