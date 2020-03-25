using System;
using HalationGhost.WinApps;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MetroWindowAndControls.Menus
{
	public class MetroWindowAndControlsViewModel : HalationGhostViewModelBase
	{
		#region プロパティ

		public ReactivePropertySlim<string> ToolTipText { get; }

		public ReactivePropertySlim<Enum> IconKind { get; }

		public ReactivePropertySlim<string> MenuText { get; }

		public ReactivePropertySlim<bool> IsEnabled { get; }

		public string NavigationPanel { get; }

		#endregion

		public MetroWindowAndControlsViewModel(Enum kind, string text, string toolTip, string navigationPanelName)
		{
			this.IconKind = new ReactivePropertySlim<Enum>(kind)
				.AddTo(this.disposable);
			this.MenuText = new ReactivePropertySlim<string>(text)
				.AddTo(this.disposable);
			this.IsEnabled = new ReactivePropertySlim<bool>(true)
				.AddTo(this.disposable);
			this.ToolTipText = new ReactivePropertySlim<string>(toolTip)
				.AddTo(this.disposable);

			this.NavigationPanel = navigationPanelName;
		}
	}
}
