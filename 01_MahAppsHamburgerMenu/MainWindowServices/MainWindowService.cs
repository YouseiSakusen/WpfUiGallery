using HalationGhost;
using MahApps.Metro.Controls;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MahAppsHamburgerMenu
{
	public class MainWindowService : BindableModelBase, IMainWindowService
	{
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		public MainWindowService()
		{
			this.HamburgerMenuDisplayMode = new ReactivePropertySlim<SplitViewDisplayMode>(SplitViewDisplayMode.CompactOverlay)
				.AddTo(this.Disposable);
			this.IsHamburgerMenuPanelOpened = new ReactivePropertySlim<bool>(false)
				.AddTo(this.Disposable);
		}
	}
}
