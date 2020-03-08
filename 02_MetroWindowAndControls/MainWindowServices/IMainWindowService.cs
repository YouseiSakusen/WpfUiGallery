using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Reactive.Bindings;

namespace MetroWindowAndControls
{
	/// <summary>MainWindowの値を中継するサービスのインタフェースを表します。</summary>
	public interface IMainWindowService
	{
		public ReactivePropertySlim<bool> IgnoreTaskbarOnMaximize { get; set; }

		public ReactivePropertySlim<bool> IsCloseButtonEnabled { get; set; }

		public ReactivePropertySlim<bool> IsMaxRestoreButtonEnabled { get; set; }

		public ReactivePropertySlim<bool> IsMinButtonEnabled { get; set; }

		public ReactivePropertySlim<bool> IsWindowDraggable { get; set; }

		public ReactivePropertySlim<bool> ShowCloseButton { get; set; }

		public ReactivePropertySlim<bool> ShowMaxRestoreButton { get; set; }

		public ReactivePropertySlim<bool> ShowMinButton { get; set; }

		public ReactivePropertySlim<bool> ShowSystemMenuOnRightClick { get; set; }

		public ReactivePropertySlim<bool> ShowTitleBar { get; set; }

		public ReactivePropertySlim<HorizontalAlignment> TitleAlignment { get; set; }

		public ReactivePropertySlim<CharacterCasing> TitleCharacterCasing { get; set; }

		public ReactivePropertySlim<bool> WindowTransitionsEnabled { get; set; }

		public ReactivePropertySlim<bool> ShowIconOnTitleBar { get; set; }

		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReactivePropertySlim<TransitionType> ContentControlTransition { get; set; }

		/// <summary>HamburgerMenuのDisplayModeを取得・設定します。</summary>
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		/// <summary>HamburgerMenuのIsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }
	}
}
