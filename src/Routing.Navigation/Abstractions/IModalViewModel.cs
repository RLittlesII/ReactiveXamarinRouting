using System;
using System.Reactive;
using System.Collections;
using System.Collections.Immutable;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Xamarin.Forms;
using System.Reactive.Concurrency;
using ReactiveUI;
using System.Reactive.Threading.Tasks;

namespace Routing.Navigation
{
    /// <summary>
    /// Interface that defines a view model for a page for the modal stack.
    /// </summary>
    public interface IModalViewModel
    {
        string Id
        {
            get;
        }
    }
}