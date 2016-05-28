using System;
using System.Reactive.Linq;

namespace GitHub.WCFRaw
{
    /// <summary>
    /// Observable Extensions
    /// </summary>
    /// <see cref="EventPublisher"/>
    public static class ObservableExtensions
    {
        /// <summary>
        /// Adds a Disposable Layer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="disposable"></param>
        /// <returns></returns>
        public static IObservable<T> AddDisposable<T>
            (this IObservable<T> source, IDisposable disposable)
        {
            return Observable.Create<T>(o =>
            {
                source.Subscribe(o);
                return disposable;
            });
        }
    }
}
