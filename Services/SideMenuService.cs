using System;

namespace Flowbite.Services
{
    public class SideMenuService : IDisposable
    {
        public bool collapseNavMenu { get; private set; } = false;

        public string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        public string? BodyCssClass => collapseNavMenu ? "flex" : "grid grid-cols-[256px_1fr]";

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