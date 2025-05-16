using System;

namespace Flowbite.Services
{
    public class SideMenuService : IDisposable
    {
        public bool collapseNavMenu { get; private set; } = false;

        public string? NavMenuCssClass => collapseNavMenu ? "w-0 overflow-hidden" : "w-64";
        public string? NavMenuItemsCssClass => collapseNavMenu ? "" : "overflow-y-auto";
        public string? BodyCssClass => collapseNavMenu ? "grid grid-cols-[1fr]" : "grid grid-cols-[256px_1fr]";

        public event Action? OnChange;

        public void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void Dispose()
        {
            OnChange = null;
        }
    }
}