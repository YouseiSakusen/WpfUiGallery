using System.Windows;
using System.Windows.Controls;
using HalationGhost.WinApps;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MetroWindowAndControls.MetroWindows
{
	public class MetroWindowPanelViewModel : HalationGhostViewModelBase
	{
		public ReadOnlyReactivePropertySlim<bool> IsEnableMinEnable { get; }

		public ReadOnlyReactivePropertySlim<bool> IsEnabledCloseEnable { get; }

		public ReadOnlyReactivePropertySlim<bool> IsEnabledMaxEnable { get; }

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

		private IMainWindowService mainWindowService = null;

		public MetroWindowPanelViewModel(IMainWindowService mainWindow)
		{
			this.mainWindowService = mainWindow;

			this.IgnoreTaskbarOnMaximize = this.mainWindowService.IgnoreTaskbarOnMaximize
				.AddTo(this.disposable);
			this.IsCloseButtonEnabled = this.mainWindowService.IsCloseButtonEnabled
				.AddTo(this.disposable);
			this.IsMaxRestoreButtonEnabled = this.mainWindowService.IsMaxRestoreButtonEnabled
				.AddTo(this.disposable);
			this.IsMinButtonEnabled = this.mainWindowService.IsMinButtonEnabled
				.AddTo(this.disposable);
			this.IsWindowDraggable = this.mainWindowService.IsWindowDraggable
				.AddTo(this.disposable);
			this.ShowCloseButton = this.mainWindowService.ShowCloseButton
				.AddTo(this.disposable);
			this.ShowMaxRestoreButton = this.mainWindowService.ShowMaxRestoreButton
				.AddTo(this.disposable);
			this.ShowMinButton = this.mainWindowService.ShowMinButton
				.AddTo(this.disposable);
			this.ShowSystemMenuOnRightClick = this.mainWindowService.ShowSystemMenuOnRightClick
				.AddTo(this.disposable);
			this.ShowTitleBar = this.mainWindowService.ShowTitleBar
				.AddTo(this.disposable);
			this.TitleAlignment = this.mainWindowService.TitleAlignment
				.AddTo(this.disposable);
			this.TitleCharacterCasing = this.mainWindowService.TitleCharacterCasing
				.AddTo(this.disposable);
			this.WindowTransitionsEnabled = this.mainWindowService.WindowTransitionsEnabled
				.AddTo(this.disposable);
			this.ShowIconOnTitleBar = this.mainWindowService.ShowIconOnTitleBar
				.AddTo(this.disposable);

			this.IsEnabledCloseEnable = new[] { this.mainWindowService.ShowTitleBar, this.mainWindowService.ShowCloseButton }
				.CombineLatestValuesAreAllTrue()
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsEnabledMaxEnable = new[] { this.mainWindowService.ShowTitleBar, this.mainWindowService.ShowMaxRestoreButton }
				.CombineLatestValuesAreAllTrue()
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
			this.IsEnableMinEnable = new[] { this.mainWindowService.ShowTitleBar, this.mainWindowService.ShowMinButton }
				.CombineLatestValuesAreAllTrue()
				.ToReadOnlyReactivePropertySlim()
				.AddTo(this.disposable);
		}
	}
}
