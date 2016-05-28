
using System;
using System.Collections.Generic;

namespace GitHub.WCFRaw.Api
{
    /// <summary>
    /// Defines an Registry for Observables
    /// </summary>
    public interface IObservableRegistry
    {
        /// <summary>
        /// Register an Observable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observable"></param>
        /// <returns></returns>
        Guid RegisterObservable<T>(IObservable<T> observable);

        /// <summary>
        /// Unregister an Observable
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool UnregisterObservable(Guid key);

        /// <summary>
        /// Get all register Observables
        /// </summary>
        /// <returns></returns>
        IObservable<IObservable<object>> GetAllObservables();

        /// <summary>
        /// Get all register Observables and their Keys
        /// </summary>
        /// <returns></returns>
        IObservable<KeyValuePair<Guid, IObservable<object>>> GetObservableKeyValues();
    }
}
