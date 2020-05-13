using MaterialDesignControls.Awesomeness;
using MaterialDesignControls.MetroWindows;
using MaterialDesignControls.MetroTextBoxes;
using MaterialDesignControls.TextBoxes;
using Prism.Ioc;
using Prism.Modularity;

namespace MaterialDesignControls
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
			containerRegistry.RegisterForNavigation<MetroTextBoxPanel, MetroTextBoxPanelViewModel>();
			containerRegistry.RegisterForNavigation<TextBoxPanel, TextBoxPanelViewModel>();
		}
	}
}