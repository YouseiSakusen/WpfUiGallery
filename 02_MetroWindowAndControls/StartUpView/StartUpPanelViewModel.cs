using HalationGhost.WinApps;
using MahApps.Metro.Controls;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MetroWindowAndControls
{
	/// <summary>
	/// MainWindowプロパティ操作ViewModelを表します。
	/// </summary>
	public class StartUpPanelViewModel : HalationGhostViewModelBase
	{
		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReactivePropertySlim<TransitionType> ContentControlTransition { get; set; }

		/// <summary>HamburgerMenuのIsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		/// <summary>HamburgerMenuのDisplayModeを取得・設定します。</summary>
		public ReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		/// <summary>MainWindoサービスを表します。</summary>
		private IMainWindowService mainWindowService = null;

		/// <summary>コンストラクタ。</summary>
		/// <param name="winService"></param>
		public StartUpPanelViewModel(IMainWindowService winService)
		{
			this.mainWindowService = winService;

			this.HamburgerMenuDisplayMode = this.mainWindowService.HamburgerMenuDisplayMode
				.AddTo(this.disposable);
			this.IsHamburgerMenuPanelOpened = this.mainWindowService.IsHamburgerMenuPanelOpened
				.AddTo(this.disposable);
			this.ContentControlTransition = this.mainWindowService.ContentControlTransition
				.AddTo(this.disposable);
		}
	}
}
