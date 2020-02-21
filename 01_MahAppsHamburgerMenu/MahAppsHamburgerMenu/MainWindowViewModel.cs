using System;
using System.Collections.ObjectModel;
using HalationGhost.WinApps;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using MahAppsHamburgerMenu.Menus;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MahAppsHamburgerMenu
{
	/// <summary>MainWindowのVM</summary>
	public class MainWindowViewModel : HalationGhostViewModelBase
	{
		#region プロパティ

		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReadOnlyReactivePropertySlim<TransitionType> ContentControlTransition { get; }

		/// <summary>HamburgerMenu.IsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		/// <summary>HamburgerMenu.DisplayModeを取得・設定します。</summary>
		public ReadOnlyReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; }

		/// <summary>HamburgerMenuで選択しているメニュー項目を取得・設定します。</summary>
		public ReactivePropertySlim<HamburgerMenuItemViewModel> SelectedMenu { get; set; }

		/// <summary>HamburgerMenuで選択しているメニュー項目のインデックスを取得・設定します。</summary>
		public ReactivePropertySlim<int> SelectedMenuIndex { get; set; }

		/// <summary>HamburgerMenuで選択しているオプションメニュー項目を取得・設定します。</summary>
		public ReactivePropertySlim<HamburgerMenuItemViewModel> SelectedOption { get; set; }

		/// <summary>HamburgerMenuで選択しているオプションメニュー項目のインデックスを取得・設定します。</summary>
		public ReactivePropertySlim<int> SelectedOptionIndex { get; set; }

		/// <summary>HamburgerMenuのメニュー項目を取得します。</summary>
		public ObservableCollection<HamburgerMenuItemViewModel> MenuItems { get; } = new ObservableCollection<HamburgerMenuItemViewModel>();

		/// <summary>HamburgerMenuのオプションメニュー項目を取得します。</summary>
		public ObservableCollection<HamburgerMenuItemViewModel> OptionMenuItems { get; } = new ObservableCollection<HamburgerMenuItemViewModel>();

		private string _title = "Prism Application";
		/// <summary>Windowのタイトルを取得・設定します。</summary>
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		#endregion

		/// <summary>タイトルバー上のHomeボタンのCommand。</summary>
		public ReactiveCommand HomeCommand { get; }

		/// <summary>ContentRenderedイベントハンドラ。</summary>
		public ReactiveCommand ContentRendered { get; }

		/// <summary>HamburgerMenuのメニュー項目選択通知イベントハンドラ。</summary>
		/// <param name="item">選択したメニュー項目を表すHamburgerMenuItemViewModel。</param>
		private void onSelectedMenu(HamburgerMenuItemViewModel item)
		{
			if (item == null)
				return;
			if (string.IsNullOrEmpty(item.NavigationPanel))
				return;

			this.regionManager.RequestNavigate("ContentRegion", item.NavigationPanel);
		}

		/// <summary>タイトルバー上のHomeボタンのコマンドハンドラ。</summary>
		private void onHome()
		{
			this.SelectedMenuIndex.Value = -1;
			this.SelectedOptionIndex.Value = -1;
			this.mainWindowService.IsHamburgerMenuPanelOpened.Value = false;
			this.regionManager.RequestNavigate("ContentRegion", "StartUpPanel");
		}

		#region コンストラクタ

		/// <summary>MainWindoサービスを表します。</summary>
		private IMainWindowService mainWindowService = null;

		/// <summary>デフォルトコンストラクタ。</summary>
		/// <param name="regionMan">IRegionManager。</param>
		/// <param name="winService">IMainWindowService。</param>
		public MainWindowViewModel(IRegionManager regionMan, IMainWindowService winService) : base(regionMan)
		{
			this.mainWindowService = winService;

			this.initialilzeMenu();

			this.SelectedMenu = new ReactivePropertySlim<HamburgerMenuItemViewModel>(null)
				.AddTo(this.disposable);
			this.SelectedMenu.Subscribe(i => this.onSelectedMenu(i));

			this.SelectedMenuIndex = new ReactivePropertySlim<int>(-1)
				.AddTo(this.disposable);

			this.SelectedOption = new ReactivePropertySlim<HamburgerMenuItemViewModel>(null)
				.AddTo(this.disposable);
			this.SelectedOption.Subscribe(o => this.onSelectedMenu(o));

			this.SelectedOptionIndex = new ReactivePropertySlim<int>(-1)
				.AddTo(this.disposable);

			this.ContentControlTransition = this.mainWindowService.ContentControlTransition
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.HamburgerMenuDisplayMode = this.mainWindowService.HamburgerMenuDisplayMode
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsHamburgerMenuPanelOpened = this.mainWindowService.IsHamburgerMenuPanelOpened
				.AddTo(this.disposable);

			this.ContentRendered = new ReactiveCommand()
				.WithSubscribe(() => this.regionManager.RequestNavigate("ContentRegion", "StartUpPanel"))
				.AddTo(this.disposable);

			this.HomeCommand = new ReactiveCommand()
				.WithSubscribe(() => this.onHome())
				.AddTo(this.disposable);
		}

		/// <summary>HamburgerMenuのメニュー項目を初期化します。</summary>
		private void initialilzeMenu()
		{
			this.MenuItems.Add(new HamburgerMenuItemViewModel(PackIconFontAwesomeKind.BugSolid, "バグ", "BugPanel"));
			this.MenuItems.Add(new HamburgerMenuItemViewModel(PackIconFontAwesomeKind.UserSolid, "ユーザ", "UserPanel"));
			this.MenuItems.Add(new HamburgerMenuItemViewModel(PackIconFontAwesomeKind.CoffeeSolid, "珈琲", "CoffeePanel"));
			this.MenuItems.Add(new HamburgerMenuItemViewModel(PackIconFontAwesomeKind.FontAwesomeBrands, "サイコー！", "AwesomePanel"));

			this.OptionMenuItems.Add(new HamburgerMenuItemViewModel(PackIconFontAwesomeKind.CogsSolid, "設定", "SettingPanel"));
			this.OptionMenuItems.Add(new HamburgerMenuItemViewModel(PackIconFontAwesomeKind.InfoCircleSolid, "このサンプルアプリについて", "AboutPanel"));
		}

		#endregion
	}
}
