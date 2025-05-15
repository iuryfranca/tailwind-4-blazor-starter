using System;

namespace Flowbite.Services
{
    public class SideMenuService : IDisposable
    {
        public bool collapseNavMenu { get; private set; } = false;

        public string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        public string? BodyCssClass => collapseNavMenu ? "w-full" : "sm:ml-[256px]";

        public event Action? OnChange;

        public void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            Console.WriteLine($"ToggleNavMenu: {collapseNavMenu}");
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void Dispose()
        {
            OnChange = null;
        }
    }
}