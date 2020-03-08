using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MetroWindowAndControls
{
	public class StartUpViewModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<StartUpPanel, StartUpPanelViewModel>();
		}
	}
}