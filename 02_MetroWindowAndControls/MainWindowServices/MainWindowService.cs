using System;
using System.Reactive.Linq;
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
		public ReactivePropertySlim<bool> WindowCloseRequest { get; }

		public ReactivePropertySlim<bool> ShowIconOnTitleBar { get; }

		public ReactivePropertySlim<bool> WindowTransitionsEnabled { get; }

		public ReactivePropertySlim<CharacterCasing> TitleCharacterCasing { get; }

		public ReactivePropertySlim<HorizontalAlignment> TitleAlignment { get; }

		public ReactivePropertySlim<bool> ShowTitleBar { get; }

		public ReactivePropertySlim<bool> ShowSystemMenuOnRightClick { get; }

		public ReactivePropertySlim<bool> ShowCloseButton { get; }

		public ReactivePropertySlim<bool> ShowMaxRestoreButton { get; }

		public ReactivePropertySlim<bool> ShowMinButton { get; }

		public ReactivePropertySlim<bool> IsWindowDraggable { get; }

		public ReactivePropertySlim<bool> IsMinButtonEnabled { get; }

		public ReactivePropertySlim<bool> IsMaxRestoreButtonEnabled { get; }

		public ReactivePropertySlim<bool> IsCloseButtonEnabled { get; }

		public ReactivePropertySlim<bool> IgnoreTaskbarOnMaximize { get; }

		public ReadOnlyReactivePropertySlim<bool> CloseEnabled { get; }

		/// <summary>HamburgerMenuのDisplayModeを取得・設定します。</summary>
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; }

		/// <summary>HamburgerMenuのIsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; }

		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReactivePropertySlim<TransitionType> ContentControlTransition { get; }

		public ReactivePropertySlim<bool> CanClose { get; }

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
			this.WindowCloseRequest = new ReactivePropertySlim<bool>(false)
				.AddTo(this.Disposable);

			this.CanClose = new ReactivePropertySlim<bool>(true)
				.AddTo(this.Disposable);

			this.CloseEnabled = this.CanClose
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.Disposable);

			this.IsCloseButtonEnabled.Subscribe(v =>
				{
					this.CanClose.Value = v &&
						this.ShowCloseButton.Value &&
						this.ShowTitleBar.Value;
				})
				.AddTo(this.Disposable);
			this.ShowTitleBar.Subscribe(v =>
				{
					this.CanClose.Value = v &&
						this.ShowCloseButton.Value &&
						this.IsCloseButtonEnabled.Value;
				})
				.AddTo(this.Disposable);
			this.ShowCloseButton.Subscribe(v =>
				{
					this.CanClose.Value = v &&
						this.ShowTitleBar.Value &&
						this.IsCloseButtonEnabled.Value;
				})
				.AddTo(this.Disposable);
			this.ShowSystemMenuOnRightClick.Subscribe(v =>
			{
				this.CanClose.Value = v &&
					this.ShowTitleBar.Value &&
					this.IsCloseButtonEnabled.Value &&
					this.ShowCloseButton.Value;
			});

			this.WindowCloseRequest.Where(v => v == true)
				.Subscribe(v => this.CanClose.Value = true)
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
