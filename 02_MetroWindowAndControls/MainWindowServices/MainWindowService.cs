using System.Windows;
using System.Windows.Controls;
using HalationGhost;
using MahApps.Metro.Controls;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MetroWindowAndControls
{
	/// <summary>
	/// MainWindowの値を中継するサービスを表します。
	/// </summary>
	public class MainWindowService : BindableModelBase, IMainWindowService
	{
		public ReactivePropertySlim<bool> ShowIconOnTitleBar { get; set; }

		public ReactivePropertySlim<bool> WindowTransitionsEnabled { get; set; }

		public ReactivePropertySlim<CharacterCasing> TitleCharacterCasing { get; set; }

		public ReactivePropertySlim<HorizontalAlignment> TitleAlignment { get; set; }

		public ReactivePropertySlim<bool> ShowTitleBar { get; set; }

		public ReactivePropertySlim<bool> ShowSystemMenuOnRightClick { get; set; }

		public ReactivePropertySlim<bool> ShowCloseButton { get; set; }

		public ReactivePropertySlim<bool> ShowMaxRestoreButton { get; set; }

		public ReactivePropertySlim<bool> ShowMinButton { get; set; }

		public ReactivePropertySlim<bool> IsWindowDraggable { get; set; }

		public ReactivePropertySlim<bool> IsMinButtonEnabled { get; set; }

		public ReactivePropertySlim<bool> IsMaxRestoreButtonEnabled { get; set; }

		public ReactivePropertySlim<bool> IsCloseButtonEnabled { get; set; }

		public ReactivePropertySlim<bool> IgnoreTaskbarOnMaximize { get; set; }

		/// <summary>HamburgerMenuのDisplayModeを取得・設定します。</summary>
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		/// <summary>HamburgerMenuのIsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReactivePropertySlim<TransitionType> ContentControlTransition { get; set; }
		
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public MainWindowService()
		{
			this.IgnoreTaskbarOnMaximize = new ReactivePropertySlim<bool>(false)
				.AddTo(this.Disposable);
			this.IsCloseButtonEnabled = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.IsMaxRestoreButtonEnabled = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.IsMinButtonEnabled = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.IsWindowDraggable = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.ShowCloseButton = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.ShowMaxRestoreButton = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.ShowMinButton = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.ShowSystemMenuOnRightClick = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.ShowTitleBar = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.TitleAlignment = new ReactivePropertySlim<HorizontalAlignment>(HorizontalAlignment.Left)
				.AddTo(this.Disposable);
			this.TitleCharacterCasing = new ReactivePropertySlim<CharacterCasing>(CharacterCasing.Normal)
				.AddTo(this.Disposable);
			this.WindowTransitionsEnabled = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);
			this.ShowIconOnTitleBar = new ReactivePropertySlim<bool>(false)
				.AddTo(this.Disposable);

			this.HamburgerMenuDisplayMode = new ReactivePropertySlim<SplitViewDisplayMode>(SplitViewDisplayMode.CompactOverlay)
				.AddTo(this.Disposable);
			this.IsHamburgerMenuPanelOpened = new ReactivePropertySlim<bool>(false)
				.AddTo(this.Disposable);
			this.ContentControlTransition = new ReactivePropertySlim<TransitionType>(TransitionType.Down)
				.AddTo(this.Disposable);
		}
	}
}
