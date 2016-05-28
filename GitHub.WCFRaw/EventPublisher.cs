using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GitHub.WCFRaw.Api;
using TvdP.Collections;

namespace GitHub.WCFRaw
{
    /// <summary>
    /// An Observable Event Aggreator
    /// </summary>
    /// <remarks>
    /// This is almost entirely ripped from a couple of blogs. 
    /// Rather then payload though, it uses the Event. 
    /// </remarks>
    /// <see href="http://keith-woods.com/Blog/category/Dev.aspx?page=1"/>
    /// <see href="http://joseoncode.com/2010/04/29/event-aggregator-with-reactive-extensions/"/>
    public class EventPublisher : IEventPublisher
    {
        // sl concurrent dictionary
        private readonly ConcurrentDictionary<Type, Tuple<object, object>>
            _observablesByPayloadType = new ConcurrentDictionary<Type, Tuple<object, object>>();

        /// <summary>
        /// Publish an Event T
        /// </summary>
        /// <typeparam name="T">event type</typeparam>
        /// <param name="evnt">event</param>
        public void Publish<T>(T evnt)
        {
            Tuple<object, object> cachedItem;

            if (_observablesByPayloadType.TryGetValue(typeof(T), out cachedItem))
                ((ISubject<T>)cachedItem.Item1).OnNext(evnt);
        }

        /// <summary>
        /// Get Event as an Observable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IObservable<T> GetEvent<T>()
        {
            var defered = Observable.Defer(() =>
            {
                var tuple = _observablesByPayloadType.GetOrAdd(typeof(T), t =>
                {
                    var subject = new Subject<T>();
                    var removeFromCache = Disposable.Create(() =>
                    {
                        Tuple<object, object> _; // throw away object! 
                        _observablesByPayloadType.TryRemove(typeof(T), out _);
                    });

                    // because we are removing items from the cache to clean up on dispose,
                    // we need to publish then refcount the subject to ensure we only  
                    // clean up when there are no subscribers left  
                    var observable = subject.AddDisposable(removeFromCache)
                        .Publish().RefCount().AsObservable();
                    return new Tuple<object, object>(subject, observable);
                });

                return (IObservable<T>)tuple.Item2;
            });

            return defered;
        }
    }
}
