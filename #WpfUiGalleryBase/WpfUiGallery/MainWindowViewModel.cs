using HalationGhost.WinApps;
using Prism.Mvvm;

namespace WpfUiGallery
{
	public class MainWindowViewModel : HalationGhostViewModelBase
	{
		private string _title = "Prism Application";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		public MainWindowViewModel()
		{

		}
	}
}
