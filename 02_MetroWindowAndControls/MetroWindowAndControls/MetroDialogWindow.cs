using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MahApps.Metro.Controls;
using Prism.Services.Dialogs;

namespace MetroWindowAndControls
{
	public partial class MetroDialogWindow : MetroWindow, IDialogWindow
	{
		public IDialogResult Result { get; set; }

		/// <summary>WindowのLoadイベントハンドラ。</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているRoutedEventArgs。</param>
		private void PersonSelectWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is IDialogAware)
				this.Title = (this.DataContext as IDialogAware).Title;

			this.Loaded -= this.PersonSelectWindow_Loaded;
		}

		/// <summary>コンストラクタ。</summary>
		public MetroDialogWindow()
		{
			this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
			this.Loaded += this.PersonSelectWindow_Loaded;
		}
	}
}
