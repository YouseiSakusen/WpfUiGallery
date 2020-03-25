using System;
using System.Reflection;
using System.Windows;
using HalationGhost.WinApps.Services;
using MetroWindowAndControls.Options;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;

namespace MetroWindowAndControls
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		/// <summary>ModuleCatalogを設定します。</summary>
		/// <param name="moduleCatalog">IModuleCatalog。</param>
		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<HalationGhostMessageBoxServiceModule>();
			moduleCatalog.AddModule<StartUpViewModule>();
			moduleCatalog.AddModule<ChildViewsModule>();
			moduleCatalog.AddModule<OptionViewsModule>();
		}

		/// <summary>ViewModelLocatorを設定します。</summary>
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

		/// <summary>Shellを作成します。</summary>
		/// <returns>Shellを表すWindow。</returns>
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		/// <summary>DIコンテナへオブジェクトを登録します。</summary>
		/// <param name="containerRegistry">DIコンテナ登録用のIContainerRegistry。</param>
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IMainWindowService, MainWindowService>();
			containerRegistry.RegisterDialogWindow<MetroDialogWindow>();
		}
	}
}
