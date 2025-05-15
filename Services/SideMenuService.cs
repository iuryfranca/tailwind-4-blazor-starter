namespace Flowbite.Services
{
    public class SideMenuService
    {
        public bool collapseNavMenu { get; set; } = true;

        public string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        public void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}