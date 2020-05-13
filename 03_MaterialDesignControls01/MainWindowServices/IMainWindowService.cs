using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Reactive.Bindings;

namespace MaterialDesignControls
{
	/// <summary>MainWindowの値を中継するサービスのインタフェースを表します。</summary>
	public interface IMainWindowService
	{
		public ReactivePropertySlim<bool> IgnoreTaskbarOnMaximize { get; }

		public ReactivePropertySlim<bool> IsCloseButtonEnabled { get; }

		public ReactivePropertySlim<bool> IsMaxRestoreButtonEnabled { get; }

		public ReactivePropertySlim<bool> IsMinButtonEnabled { get; }

		public ReactivePropertySlim<bool> IsWindowDraggable { get; }

		public ReactivePropertySlim<bool> ShowCloseButton { get; }

		public ReactivePropertySlim<bool> ShowMaxRestoreButton { get; }

		public ReactivePropertySlim<bool> ShowMinButton { get; }

		public ReactivePropertySlim<bool> ShowSystemMenuOnRightClick { get; }

		public ReactivePropertySlim<bool> ShowTitleBar { get; }

		public ReactivePropertySlim<HorizontalAlignment> TitleAlignment { get; }

		public ReactivePropertySlim<CharacterCasing> TitleCharacterCasing { get; }

		public ReactivePropertySlim<bool> WindowTransitionsEnabled { get; }

		public ReactivePropertySlim<bool> ShowIconOnTitleBar { get; }

		public ReadOnlyReactivePropertySlim<bool> CloseEnabled { get; }

		public ReactivePropertySlim<bool> CanClose { get; }

		public ReactivePropertySlim<bool> WindowCloseRequest { get; }

		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReactivePropertySlim<TransitionType> ContentControlTransition { get; }

		/// <summary>HamburgerMenuのDisplayModeを取得・設定します。</summary>
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; }

		/// <summary>HamburgerMenuのIsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; }
	}
}
