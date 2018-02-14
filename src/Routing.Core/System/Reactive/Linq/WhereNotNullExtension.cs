using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Reactive.Linq
{
    public static class WhereNotNullExtension
    {
        public static IObservable<T> WhereNotNull<T>(this IObservable<T> observable)
        {
            return observable.Where(x => x != null);
        }
    }
}