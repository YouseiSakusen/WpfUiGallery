using Prism.Ioc;
using Prism.Modularity;

namespace MahAppsNetCore
{
	public class LoadableViewsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<StartupPage, StartupPageViewModel>();
		}
	}
}