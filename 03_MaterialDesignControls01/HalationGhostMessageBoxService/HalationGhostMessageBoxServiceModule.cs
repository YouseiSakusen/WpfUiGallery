using HalationGhost.WinApps.Services.MessageBoxes;
using Prism.Ioc;
using Prism.Modularity;

namespace HalationGhost.WinApps.Services
{
	public class HalationGhostMessageBoxServiceModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterDialog<NotifyMessageBox, NotifyMessageBoxViewModel>();
			containerRegistry.RegisterDialog<ConfirmedMessageBox, ConfirmedMessageBoxViewModel>();
		}
	}
}