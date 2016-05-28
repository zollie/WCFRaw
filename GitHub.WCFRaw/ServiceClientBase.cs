using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.ServiceModel;
using System.ServiceModel.Channels;
using GitHub.WCFRaw.Api;

namespace GitHub.WCFRaw
{
    /// <summary>
    /// A WCF Service Client that is Observable
    /// </summary>
    /// <typeparam name="A">request</typeparam>
    /// <typeparam name="B">response</typeparam>
    public class ServiceClientBase<A, B>
        : ClientBase<IAsyncRequestChannel<A, B>>,
        IServiceClient<A, B>
    {
        /// <summary>
        /// Observable subject
        /// </summary>
        private readonly ISubject<B> _subject = new Subject<B>();

        /// <summary>
        /// Async Service Request Func used for Observable
        /// </summary>
        private readonly Func<Message, IObservable<Message>> _serviceRequest;

        /// <summary>
        /// Wcf Request Message Marshaller
        /// </summary>
        public IMap<A, Message> RequestMessageMapper { get; set; }

        /// <summary>
        /// Wcf Response Message Marshaller
        /// </summary>
        public IMap<Message, B> ResponseMessageMapper { get; set; }

        /// <summary>
        /// Ctor that requires Binding and endpoint uri. 
        /// Sets properties to defaults. 
        /// </summary>
        /// <param name="binding">type of Binding</param>
        /// <param name="endpoint">Uri</param>
        public ServiceClientBase(Binding binding, EndpointAddress endpoint)
            : base(binding, endpoint)
        {
            _serviceRequest = Observable.FromAsyncPattern<Message, Message>
                (Channel.BeginRequest, Channel.EndRequest);
        }

        /// <summary>
        /// Synchronous request
        /// </summary>
        /// <remarks>
        /// This syncronous method will not work in Silveright. 
        /// It is here for .NET clients
        /// </remarks>
        /// <param name="request">any request xml</param>
        /// <returns>any response xml</returns>
        public B Service(A request)
        {
            try
            {
                var message = RequestMessageMapper.Map(request);
                var response = Channel.Request(message);
                var result = ResponseMessageMapper.Map(response);
                _subject.OnNext(result);
                return ResponseMessageMapper.Map(response);
            }
            catch (Exception e)
            {
                _subject.OnError(e);
                throw;
            }
        }

        /// <summary>
        /// Service Request as a future Observable
        /// </summary>
        /// <remarks>
        /// This is the async version suitable for Silveright
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        public IObservable<B> AsObservable(A request)
        {
            // create observable
            var q =
                from message in RequestMessageMapper.AsObservable(request)
                from response in _serviceRequest(message)
                let result = ResponseMessageMapper.Map(response)
                select result;

            return q;
        }

        /// <summary>
        /// Observable for all requests
        /// </summary>
        /// <returns></returns>
        public IObservable<B> AsObservable()
        {
            return _subject;
        }
    }
}
