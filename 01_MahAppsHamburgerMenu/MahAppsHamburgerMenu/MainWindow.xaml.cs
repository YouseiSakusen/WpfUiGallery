using System.Windows;
using CommonServiceLocator;
using MahApps.Metro.Controls;
using Prism.Regions;

namespace MahAppsHamburgerMenu
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			RegionManager.SetRegionName(this.ContentRegion, "ContentRegion");

			var regionMan = ServiceLocator.Current.GetInstance<IRegionManager>();
			RegionManager.SetRegionManager(this.ContentRegion, regionMan);
		}
	}
}
