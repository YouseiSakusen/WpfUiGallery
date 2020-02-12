using System;
using System.Collections.Generic;
using System.Text;
using MahApps.Metro.Controls;
using Reactive.Bindings;

namespace MahAppsHamburgerMenu
{
	public interface IMainWindowService
	{
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }
	}
}
