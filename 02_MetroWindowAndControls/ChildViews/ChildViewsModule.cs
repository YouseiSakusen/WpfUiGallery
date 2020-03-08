using MetroWindowAndControls.Awesomeness;
using MetroWindowAndControls.MetroWindows;
using MetroWindowAndControls.Coffees;
using MetroWindowAndControls.TextBoxes;
using Prism.Ioc;
using Prism.Modularity;

namespace MetroWindowAndControls
{
	public class ChildViewsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<AwesomePanel, AwesomePanelViewModel>();
			containerRegistry.RegisterForNavigation<MetroWindowPanel, MetroWindowPanelViewModel>();
			containerRegistry.RegisterForNavigation<CoffeePanel, CoffeePanelViewModel>();
			containerRegistry.RegisterForNavigation<TextBoxPanel, TextBoxPanelViewModel>();
		}
	}
}