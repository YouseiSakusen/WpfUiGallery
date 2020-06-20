using Prism.Mvvm;
using Prism.Regions;

namespace MahAppsNetCore
{
	public class MainWindowViewModel : BindableBase
	{
		public MainWindowViewModel(IRegionManager regMan)
		{
			regMan.RegisterViewWithRegion("PageArea", typeof(StartupPage));
		}
	}
}
