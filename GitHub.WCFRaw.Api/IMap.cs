using System;
using System.Reactive.Linq;

namespace GitHub.WCFRaw.Api
{
    /// <summary>
    /// A Map of A => B
    /// </summary>
    /// <remarks>
    /// Maybe create a Linq provider 
    /// for this interface much like IObservable. 
    /// 
    /// Map is from Category Theory. You could call this IFunc. 
    /// Func in the BCL is a delegate so is not a first class 
    /// citizen of the language so using things like Linq over 
    /// it are not possible.    
    /// </remarks>
    /// <typeparam name="A">from</typeparam>
    /// <typeparam name="B">to</typeparam>
    public interface IMap<in A, out B>
    {
        /// <summary>
        /// A Function or Map of A => B
        /// </summary>
        /// <param name="from">from</param>
        /// <returns>to</returns>  
        B Map(A from);
    }

    /// <summary>
    /// IMap mixin extensions
    /// </summary>
    public static class MapExtensions
    {
        /// <summary>
        /// Create an Observable out of any IMap
        /// </summary>
        /// <remarks>
        /// This lets you use Linq over IMaps
        /// </remarks>
        /// <typeparam name="A">from</typeparam>
        /// <typeparam name="B">to</typeparam>
        /// <param name="map">this</param>
        /// <param name="from">observable of B</param>
        /// <returns></returns>
        public static IObservable<B> AsObservable<A, B>(this IMap<A, B> map, A from)
        {
            return Observable.Create<B>(observer =>
            {
                try
                {
                    observer.OnNext(map.Map(from));
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                }

                return observer.OnCompleted;
            });
        }
    }
}
