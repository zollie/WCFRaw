using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GitHub.WCFRaw.Api;
using TvdP.Collections;

namespace GitHub.WCFRaw
{
    /// <summary>
    /// Default Implementation of IObservableRegistry
    /// </summary>
    /// <remarks>
    /// Use Linq to find the Observable you want to subscribe too
    /// </remarks>
    public class ObservableRegistry : IObservableRegistry
    {
        // internal registry
        private readonly ConcurrentDictionary<Guid, IObservable<object>>
            _registry = new ConcurrentDictionary<Guid, IObservable<object>>();

        /// <summary>
        /// Register an Observable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observable"></param>
        /// <returns></returns>
        public Guid RegisterObservable<T>(IObservable<T> observable)
        {
            var guid = new Guid();
            _registry.TryAdd(guid, (IObservable<object>)observable);
            return guid;
        }

        /// <summary>
        /// Unregister an Observable
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool UnregisterObservable(Guid key)
        {
            IObservable<object> toOut;
            return _registry.TryRemove(key, out toOut);
        }

        /// <summary>
        /// Get all register Observables
        /// </summary>
        /// <returns></returns>
        public IObservable<IObservable<object>> GetAllObservables()
        {
            return _registry.Values.ToObservable();
        }

        /// <summary>
        /// Get all register Observables and their Keys
        /// </summary>
        /// <returns></returns>
        public IObservable<KeyValuePair<Guid, IObservable<object>>> GetObservableKeyValues()
        {
            return _registry.ToObservable();
        }
    }
}
