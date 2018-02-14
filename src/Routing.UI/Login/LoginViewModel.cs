using ReactiveUI;
using Routing.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.UI.Login
{
    public class LoginViewModel : BaseViewModel, IPageViewModel
    {
        public string Id => nameof(LoginViewModel);

        public LoginViewModel(IViewStackService viewStackService) : base(viewStackService)
        {
        }
    }
}