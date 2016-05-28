using System;

namespace GitHub.WCFRaw.Api
{
    /// <summary>
    /// Defines an Observable Event Mediator
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish Event T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evnt"></param>
        void Publish<T>(T evnt);

        /// <summary>
        /// Get Event T as an Observable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IObservable<T> GetEvent<T>();
    }
}
