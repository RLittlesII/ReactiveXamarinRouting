using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.UI
{
    public sealed class FormsViewLocator : IViewLocator
    {
        public Func<string, string> ViewModelToViewFunc { get; set; }

        public FormsViewLocator(Func<string, string> viewModelToViewFunc = null)
        {
            ViewModelToViewFunc = viewModelToViewFunc ?? (vm => vm.Replace("ViewModel", "View"));
        }

        public IViewFor ResolveView<T>(T viewModel, string contract = null) where T : class
        {
            throw new NotImplementedException();
        }
    }
}