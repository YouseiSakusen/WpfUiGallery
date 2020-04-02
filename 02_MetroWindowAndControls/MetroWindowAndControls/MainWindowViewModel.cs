using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using CommonServiceLocator;
using HalationGhost.WinApps;
using HalationGhost.WinApps.Services.MessageBoxes;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using MetroWindowAndControls.Menus;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MetroWindowAndControls
{
	/// <summary>MainWindowのVM</summary>
	public class MainWindowViewModel : HalationGhostViewModelBase
	{
		#region プロパティ

		public ReadOnlyReactivePropertySlim<bool> ShowIconOnTitleBar { get; }

		public ReadOnlyReactivePropertySlim<bool> WindowTransitionsEnabled { get; }

		public ReadOnlyReactivePropertySlim<bool> IgnoreTaskbarOnMaximize { get; }

		public ReadOnlyReactivePropertySlim<bool> IsCloseButtonEnabled { get; }

		public ReadOnlyReactivePropertySlim<bool> IsMaxRestoreButtonEnabled { get; }

		public ReadOnlyReactivePropertySlim<bool> IsMinButtonEnabled { get; }

		public ReadOnlyReactivePropertySlim<bool> IsWindowDraggable { get; }

		public ReadOnlyReactivePropertySlim<bool> ShowCloseButton { get; }

		public ReadOnlyReactivePropertySlim<bool> ShowMaxRestoreButton { get; }

		public ReadOnlyReactivePropertySlim<bool> ShowMinButton { get; }

		public ReadOnlyReactivePropertySlim<bool> ShowSystemMenuOnRightClick { get; }

		public ReadOnlyReactivePropertySlim<bool> ShowTitleBar { get; }

		public ReadOnlyReactivePropertySlim<HorizontalAlignment> TitleAlignment { get; }

		public ReadOnlyReactivePropertySlim<CharacterCasing> TitleCharacterCasing { get; }

		public ReadOnlyReactivePropertySlim<bool> CanClose { get; }

		public ReadOnlyReactivePropertySlim<bool> CanMaxmize { get; }

		public ReadOnlyReactivePropertySlim<bool> CanMinimize { get; }

		public ReadOnlyReactivePropertySlim<bool> RequestClose { get; }

		/// <summary>TransitioningContentControlのTransitionを取得・設定します。</summary>
		public ReadOnlyReactivePropertySlim<TransitionType> ContentControlTransition { get; }

		/// <summary>HamburgerMenu.IsPaneOpenを取得・設定します。</summary>
		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		/// <summary>HamburgerMenu.DisplayModeを取得・設定します。</summary>
		public ReadOnlyReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; }

		/// <summary>HamburgerMenuで選択しているメニュー項目を取得・設定します。</summary>
		public ReactivePropertySlim<MetroWindowAndControlsViewModel> SelectedMenu { get; }

		/// <summary>HamburgerMenuで選択しているメニュー項目のインデックスを取得・設定します。</summary>
		public ReactivePropertySlim<int> SelectedMenuIndex { get; }

		/// <summary>HamburgerMenuで選択しているオプションメニュー項目を取得・設定します。</summary>
		public ReactivePropertySlim<MetroWindowAndControlsViewModel> SelectedOption { get; }

		/// <summary>HamburgerMenuで選択しているオプションメニュー項目のインデックスを取得・設定します。</summary>
		public ReactivePropertySlim<int> SelectedOptionIndex { get; }

		/// <summary>HamburgerMenuのメニュー項目を取得します。</summary>
		public ObservableCollection<MetroWindowAndControlsViewModel> MenuItems { get; } = new ObservableCollection<MetroWindowAndControlsViewModel>();

		/// <summary>HamburgerMenuのオプションメニュー項目を取得します。</summary>
		public ObservableCollection<MetroWindowAndControlsViewModel> OptionMenuItems { get; } = new ObservableCollection<MetroWindowAndControlsViewModel>();

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

		public ReactiveCommand CloseCancel { get; }

		/// <summary>HamburgerMenuのメニュー項目選択通知イベントハンドラ。</summary>
		/// <param name="item">選択したメニュー項目を表すHamburgerMenuItemViewModel。</param>
		private void onSelectedMenu(MetroWindowAndControlsViewModel item)
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

		private void onCloseCancel()
		{
			//this.mainWindowService.CanClose.Value = this.dialogService.ShowConfirmationMessage("Windowを閉じる？") == ButtonResult.Yes;
			//this.mainWindowService.WindowCloseRequest.Value = false;
		}

		#region コンストラクタ

		/// <summary>MainWindoサービスを表します。</summary>
		private IMainWindowService mainWindowService = null;
		/// <summary>Dialogサービスを表します。</summary>
		private IDialogService dialogService = null;

		/// <summary>デフォルトコンストラクタ。</summary>
		/// <param name="regionMan">IRegionManager。</param>
		/// <param name="winService">IMainWindowService。</param>
		public MainWindowViewModel(IRegionManager regionMan, IMainWindowService winService, IDialogService dlgService) : base(regionMan)
		{
			this.mainWindowService = winService;
			this.dialogService = dlgService;

			this.IgnoreTaskbarOnMaximize = this.mainWindowService.IgnoreTaskbarOnMaximize
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsCloseButtonEnabled = this.mainWindowService.IsCloseButtonEnabled
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsMaxRestoreButtonEnabled = this.mainWindowService.IsMaxRestoreButtonEnabled
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsMinButtonEnabled = this.mainWindowService.IsMinButtonEnabled
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsWindowDraggable = this.mainWindowService.IsWindowDraggable
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.ShowCloseButton = this.mainWindowService.ShowCloseButton
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.ShowMaxRestoreButton = this.mainWindowService.ShowMaxRestoreButton
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.ShowMinButton = this.mainWindowService.ShowMinButton
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.ShowSystemMenuOnRightClick = this.mainWindowService.ShowSystemMenuOnRightClick
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.ShowTitleBar = this.mainWindowService.ShowTitleBar
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.TitleAlignment = this.mainWindowService.TitleAlignment
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.TitleCharacterCasing = this.mainWindowService.TitleCharacterCasing
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.WindowTransitionsEnabled = this.mainWindowService.WindowTransitionsEnabled
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.ShowIconOnTitleBar = this.mainWindowService.ShowIconOnTitleBar
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);

			this.CanMaxmize = new[]
				{
					this.mainWindowService.ShowMaxRestoreButton,
					this.mainWindowService.IsMaxRestoreButtonEnabled
				}
				.CombineLatestValuesAreAllTrue()
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.CanMinimize = new[]
				{
					this.mainWindowService.ShowMinButton,
					this.mainWindowService.IsMinButtonEnabled
				}
				.CombineLatestValuesAreAllTrue()
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);

			this.CanClose = this.mainWindowService.CloseEnabled
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.RequestClose = this.mainWindowService.WindowCloseRequest
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
				
			this.initialilzeMenu();

			this.SelectedMenu = new ReactivePropertySlim<MetroWindowAndControlsViewModel>(null)
				.AddTo(this.disposable);
			this.SelectedMenu.Subscribe(i => this.onSelectedMenu(i));

			this.SelectedMenuIndex = new ReactivePropertySlim<int>(-1)
				.AddTo(this.disposable);

			this.SelectedOption = new ReactivePropertySlim<MetroWindowAndControlsViewModel>(null)
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
			this.CloseCancel = new ReactiveCommand()
				.WithSubscribe(() => this.onCloseCancel())
				.AddTo(this.disposable);
		}

		/// <summary>HamburgerMenuのメニュー項目を初期化します。</summary>
		private void initialilzeMenu()
		{
			this.MenuItems.Add(new MetroWindowAndControlsViewModel(PackIconMaterialKind.WindowMaximize, "MetroWindow", "MetroWindowプロパティのデモ", "MetroWindowPanel"));
			this.MenuItems.Add(new MetroWindowAndControlsViewModel(PackIconModernKind.InterfaceTextbox, "TextBox", string.Empty, "TextBoxPanel"));
			this.MenuItems.Add(new MetroWindowAndControlsViewModel(PackIconFontAwesomeKind.CoffeeSolid, "珈琲", string.Empty, "CoffeePanel"));
			this.MenuItems.Add(new MetroWindowAndControlsViewModel(PackIconFontAwesomeKind.FontAwesomeBrands, "サイコー！", string.Empty, "AwesomePanel"));

			this.OptionMenuItems.Add(new MetroWindowAndControlsViewModel(PackIconFontAwesomeKind.CogsSolid, "設定", string.Empty, "SettingPanel"));
			this.OptionMenuItems.Add(new MetroWindowAndControlsViewModel(PackIconFontAwesomeKind.InfoCircleSolid, "このサンプルアプリについて", string.Empty, "AboutPanel"));
		}

		#endregion
	}
}
