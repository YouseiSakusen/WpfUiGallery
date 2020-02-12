using System;
using HalationGhost.WinApps;
using MahApps.Metro.Controls;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MahAppsHamburgerMenu
{
	public class StartUpPanelViewModel : HalationGhostViewModelBase
	{
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		private IMainWindowService mainWindowService = null;

		public StartUpPanelViewModel(IMainWindowService winService)
		{
			this.mainWindowService = winService;

			this.HamburgerMenuDisplayMode = this.mainWindowService.HamburgerMenuDisplayMode
				.AddTo(this.disposable);
			this.IsHamburgerMenuPanelOpened = this.mainWindowService.IsHamburgerMenuPanelOpened
				.AddTo(this.disposable);
		}
	}
}
