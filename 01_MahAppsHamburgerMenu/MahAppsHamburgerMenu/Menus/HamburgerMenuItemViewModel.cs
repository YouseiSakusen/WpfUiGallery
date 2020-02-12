using HalationGhost.WinApps;
using MahApps.Metro.IconPacks;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MahAppsHamburgerMenu.Menus
{
	public class HamburgerMenuItemViewModel : HalationGhostViewModelBase
	{
		#region プロパティ

		public ReactivePropertySlim<PackIconFontAwesomeKind> IconKind { get; }

		public ReactivePropertySlim<string> MenuText { get; }

		public string NavigationPanel { get; }

		#endregion

		public HamburgerMenuItemViewModel(PackIconFontAwesomeKind kind, string text, string navigationPanelName)
		{
			this.IconKind = new ReactivePropertySlim<PackIconFontAwesomeKind>(kind)
				.AddTo(this.disposable);
			this.MenuText = new ReactivePropertySlim<string>(text)
				.AddTo(this.disposable);

			this.NavigationPanel = navigationPanelName;
		}
	}
}
