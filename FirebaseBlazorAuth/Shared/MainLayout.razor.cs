using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirebaseBlazorAuth.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject]
        NavigationManager? NavigationManager { get; set; }

        public bool _drawerOpen = true;

        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        private void NavigateToAccount()
        {
            NavigationManager.NavigateToLogin("/account");
        }
        private void NavigateToLogin()
        {
            NavigationManager.NavigateToLogin("/login");
        }

    }
}
