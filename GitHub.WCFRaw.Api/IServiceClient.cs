using System;

namespace GitHub.WCFRaw.Api
{
    /// <summary>
    /// Definition of a Service Client
    /// </summary>
    /// <remarks>
    /// WCF RIA Services does not work with large complicated WSDLs
    /// so we create our own framework starting here. 
    /// This purposely does not use IMap as we want more
    /// control over the Observable
    /// </remarks>
    /// <typeparam name="A">request type</typeparam>
    /// <typeparam name="B">response type</typeparam>
    public interface IServiceClient<in A, out B>
    {
        /// <summary>
        /// Synchronous request
        /// </summary>
        /// <param name="request">any request xml</param>
        /// <returns>any response xml</returns>
        B Service(A request);

        /// <summary>
        /// Service Request as a future Observable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IObservable<B> AsObservable(A request);

        /// <summary>
        /// Observable for all requests
        /// </summary>
        /// <returns></returns>
        IObservable<B> AsObservable();
    }
}
