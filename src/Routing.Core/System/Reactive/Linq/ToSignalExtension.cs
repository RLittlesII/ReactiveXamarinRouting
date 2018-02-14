using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Reactive.Linq
{
    public static class ToSignalExtension
    {
        public static IObservable<Unit> ToSignal<T>(this IObservable<T> @this)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }
            return @this
                .Select(_ => Unit.Default);
        }
    }
}