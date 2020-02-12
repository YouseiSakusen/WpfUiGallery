using System;
using System.Reflection;
using System.Windows;
using MahAppsHamburgerMenu.Options;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;

namespace MahAppsHamburgerMenu
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<StartUpViewModule>();
			moduleCatalog.AddModule<ChildViewsModule>();
			moduleCatalog.AddModule<OptionViewsModule>();
		}

		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();

			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(vt =>
			{
				var viewName = vt.FullName;
				var asmName = vt.GetTypeInfo().Assembly.FullName;
				var vmName = $"{viewName}ViewModel, {asmName}";

				return Type.GetType(vmName);
			});
		}

		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IMainWindowService, MainWindowService>();
		}
	}
}
