using HalationGhost;
using MahApps.Metro.Controls;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MahAppsHamburgerMenu
{
	/// <summary>
	/// MainWindowの値を中継するサービスを表します。
	/// </summary>
	public class MainWindowService : BindableModelBase, IMainWindowService
	{
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
			this.HamburgerMenuDisplayMode = new ReactivePropertySlim<SplitViewDisplayMode>(SplitViewDisplayMode.CompactOverlay)
				.AddTo(this.Disposable);
			this.IsHamburgerMenuPanelOpened = new ReactivePropertySlim<bool>(false)
				.AddTo(this.Disposable);
			this.ContentControlTransition = new ReactivePropertySlim<TransitionType>(TransitionType.Default)
				.AddTo(this.Disposable);
		}
	}
}
