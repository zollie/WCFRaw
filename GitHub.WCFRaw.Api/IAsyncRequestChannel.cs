using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GitHub.WCFRaw.Api
{
    /// <summary>
    /// Interface for async WCF clients (works w/ Silverlight). 
    /// IRequestChannel gives us low-level access to 
    /// the WCF Message class for complete control of wire format. 
    /// This Interface is not actually used. It's just to trick
    /// the Silverlight version of WCF. 
    /// </summary>
    /// <remarks>
    /// You should not have to implement this directly. This
    /// is for low-level WCF access. Extend or use an ServiceClient class
    /// that implements IServiceClient or other derivative instead. 
    /// </remarks>
    /// <typeparam name="A">request</typeparam>
    /// <typeparam name="B">response</typeparam>
    [ServiceContract]
    public interface IAsyncRequestChannel<in A, out B>
        : IRequestChannel
    {
        /// <summary>
        /// Async Service Request. 
        /// </summary>
        /// <param name="request">request xml</param>
        /// <param name="callback">callback</param>
        /// <param name="asyncState">inter-thread comm state</param>
        /// <returns></returns>
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginService
            (A request, AsyncCallback callback, object asyncState = null);

        /// <summary>
        /// Counterpoint to BeginService. 
        /// Silverlight demands this pattern. 
        /// </summary>
        /// <param name="result">callback result</param>
        /// <returns>response xml</returns>
        B EndService(IAsyncResult result);
    }
}
