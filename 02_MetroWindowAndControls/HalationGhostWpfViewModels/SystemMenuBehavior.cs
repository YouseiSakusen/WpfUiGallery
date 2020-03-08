using System;
using System.Windows;
using System.Windows.Interop;
using HalationGhost.Win32Api;
using Microsoft.Xaml.Behaviors;

namespace HalationGhost.WinApps
{
	public class SystemMenuBehavior : Behavior<Window>
	{
		#region プロパティ

		public bool? IsVisible
		{
			get { return (bool?)GetValue(IsVisibleProperty); }
			set { SetValue(IsVisibleProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsVisible.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsVisibleProperty =
			DependencyProperty.Register("IsVisible",
							   typeof(bool?),
							   typeof(SystemMenuBehavior),
							   new PropertyMetadata(null, SystemMenuBehavior.OnPropertyChanged));

		public bool AltF4Enabled
		{
			get { return (bool)GetValue(AltF4EnabledProperty); }
			set { SetValue(AltF4EnabledProperty, value); }
		}

		// Using a DependencyProperty as the backing store for AltF4Enabled.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AltF4EnabledProperty =
			DependencyProperty.Register("AltF4Enabled", typeof(bool), typeof(SystemMenuBehavior), new PropertyMetadata(true));

		#endregion

		#region overrides

		protected override void OnAttached()
		{
			this.AssociatedObject.SourceInitialized += this.onSourceInitialized;
			base.OnAttached();
		}

		protected override void OnDetaching()
		{
			//var source = (HwndSource)HwndSource.FromVisual(this.AssociatedObject);
			//source.RemoveHook(this.windowProc);

			this.AssociatedObject.SourceInitialized -= this.onSourceInitialized;
			base.OnDetaching();
		}

		#endregion

		private void onSourceInitialized(object sender, EventArgs e)
		{
			//var source = (HwndSource)HwndSource.FromVisual(this.AssociatedObject);
			//source.AddHook(this.windowProc);
		}

		private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var me = d as SystemMenuBehavior;
			if (me != null)
				me.applyProperties();
		}

		private void applyProperties()
		{
			if (this.AssociatedObject == null)
				return;

			if (this.IsVisible.HasValue)
			{
				var hwnd = new WindowInteropHelper(this.AssociatedObject).Handle;
				WindowApis.ChangeSystemMenuVisible(hwnd, this.IsVisible.Value);
			}
		}

		//private IntPtr windowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		//{
		//	// Alt + F4を無効化
		//	if (!this.AltF4Enabled)
		//	{
		//		if (msg == ApiConstants.WM_SYSKEYDOWN)
		//		{
		//			if (wParam.ToInt32() == ApiConstants.VK_F4)
		//				handled = true;
		//		}
		//	}

		//	return IntPtr.Zero;
		//}
	}
}
