using MahAppsHamburgerMenu.Awesomeness;
using MahAppsHamburgerMenu.Bugs;
using MahAppsHamburgerMenu.Coffees;
using MahAppsHamburgerMenu.Users;
using Prism.Ioc;
using Prism.Modularity;

namespace MahAppsHamburgerMenu
{
	public class ChildViewsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<AwesomePanel, AwesomePanelViewModel>();
			containerRegistry.RegisterForNavigation<BugPanel, BugPanelViewModel>();
			containerRegistry.RegisterForNavigation<CoffeePanel, CoffeePanelViewModel>();
			containerRegistry.RegisterForNavigation<UserPanel, UserPanelViewModel>();
		}
	}
}