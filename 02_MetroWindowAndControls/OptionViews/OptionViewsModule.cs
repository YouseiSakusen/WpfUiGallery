﻿using MetroWindowAndControls.Options.Settings;
using Prism.Ioc;
using Prism.Modularity;

namespace MetroWindowAndControls.Options
{
	public class OptionViewsModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{

		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<SettingPanel, SettingPanelViewModel>();
			containerRegistry.RegisterForNavigation<AboutPanel, AboutPanelViewModel>();
		}
	}
}