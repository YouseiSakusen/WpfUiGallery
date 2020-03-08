using System.Windows.Media;
using HalationGhost.WinApps;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MetroWindowAndControls.MetroWindows
{
	public class BrushItemViewModel : HalationGhostViewModelBase
	{
		public ReactivePropertySlim<string> ItemText { get; }

		public ReactivePropertySlim<Brush> BrushColor { get; }

		public BrushItemViewModel(string colorName, object brushColor)
		{
			this.ItemText = new ReactivePropertySlim<string>(colorName)
				.AddTo(this.disposable);
			this.BrushColor = new ReactivePropertySlim<Brush>(brushColor as Brush)
				.AddTo(this.disposable);
		}
	}
}
