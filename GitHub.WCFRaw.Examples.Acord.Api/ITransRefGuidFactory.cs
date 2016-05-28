namespace GitHub.WCFRaw.Examples.Acord.Api
{
    /// <summary>
    /// Factory for Acord TransRefGuid
    /// </summary>
    public interface ITransRefGuidFactory
    {
        /// <summary>
        /// Return new guid
        /// </summary>
        /// <returns>new TransRefGuid</returns>
        string NewTransRefGuid();
    }
}
