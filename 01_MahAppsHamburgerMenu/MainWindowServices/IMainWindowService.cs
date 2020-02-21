using MahApps.Metro.Controls;
using Reactive.Bindings;

namespace MahAppsHamburgerMenu
{
	/// <summary>MainWindowの値を中継するサービスのインタフェースを表します。</summary>
	public interface IMainWindowService
	{
		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReactivePropertySlim<TransitionType> ContentControlTransition { get; set; }

		/// <summary>HamburgerMenuのDisplayModeを取得・設定します。</summary>
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		/// <summary>HamburgerMenuのIsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }
	}
}
