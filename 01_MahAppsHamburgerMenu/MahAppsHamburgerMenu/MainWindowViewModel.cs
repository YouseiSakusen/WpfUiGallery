﻿using System;
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
	public class MainWindowViewModel : HalationGhostViewModelBase
	{
		#region プロパティ

		public ReactivePropertySlim<bool> IsHamburgerMenuPanelOpened { get; set; }

		public ReadOnlyReactivePropertySlim<SplitViewDisplayMode> HamburgerMenuDisplayMode { get; set; }

		public ReactivePropertySlim<HamburgerMenuItemViewModel> SelectedMenu { get; set; }

		public ReactivePropertySlim<int> SelectedMenuIndex { get; set; }

		public ReactivePropertySlim<HamburgerMenuItemViewModel> SelectedOption { get; set; }

		public ReactivePropertySlim<int> SelectedOptionIndex { get; set; }

		public ObservableCollection<HamburgerMenuItemViewModel> MenuItems { get; } = new ObservableCollection<HamburgerMenuItemViewModel>();

		public ObservableCollection<HamburgerMenuItemViewModel> OptionMenuItems { get; } = new ObservableCollection<HamburgerMenuItemViewModel>();

		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		#endregion

		public ReactiveCommand HomeCommand { get; }

		public ReactiveCommand ContentRendered { get; }

		private void onSelectedMenu(HamburgerMenuItemViewModel item)
		{
			if (item == null)
				return;
			if (string.IsNullOrEmpty(item.NavigationPanel))
				return;

			this.regionManager.RequestNavigate("ContentRegion", item.NavigationPanel);
		}

		private void onHome()
		{
			this.SelectedMenuIndex.Value = -1;
			this.SelectedOptionIndex.Value = -1;
			this.mainWindowService.IsHamburgerMenuPanelOpened.Value = false;
			this.regionManager.RequestNavigate("ContentRegion", "StartUpPanel");
		}

		#region コンストラクタ

		private IMainWindowService mainWindowService = null;

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
