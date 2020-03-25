using System;
using System.Runtime.InteropServices;

namespace HalationGhost.Win32Api
{
	public static class WindowApis
	{
		#region DllImports

		[DllImport("user32")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwLong);

		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

		[DllImport("user32.dll")]
		private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

		#endregion

		public static void ChangeSystemMenuVisible(IntPtr hWnd, bool visible)
		{
			var style = WindowApis.GetWindowLong(hWnd, ApiConstants.GWL_STYLE);
			if (visible)
				style |= ApiConstants.WS_SYSMENU;
			else
				style &= ~ApiConstants.WS_SYSMENU;

			WindowApis.SetWindowLong(hWnd, ApiConstants.GWL_STYLE, style);
		}

		public static void ChangeWindowStyle(IntPtr hWnd, MetroWindowStyle styleFlag)
		{
			var style = WindowApis.GetWindowLong(hWnd, ApiConstants.GWL_STYLE);

			if ((styleFlag & MetroWindowStyle.CanMaxmize) == MetroWindowStyle.CanMaxmize)
				style |= ApiConstants.WS_MAXIMIZEBOX;
			else
				style &= ~ApiConstants.WS_MAXIMIZEBOX;

			if ((styleFlag & MetroWindowStyle.CanMinimize) == MetroWindowStyle.CanMinimize)
				style |= ApiConstants.WS_MINIMIZEBOX;
			else
				style &= ~ApiConstants.WS_MINIMIZEBOX;

			if ((styleFlag & MetroWindowStyle.ShowSystemMenu) == MetroWindowStyle.ShowSystemMenu)
				style |= ApiConstants.WS_SYSMENU;
			else
				style &= ~ApiConstants.WS_SYSMENU;

			WindowApis.SetWindowLong(hWnd, ApiConstants.GWL_STYLE, style);
		}

		public static void ChangeSystemMenuItemEnabled(IntPtr hWnd, SystemMenuItem menuItem, bool isEnabled)
		{
			var hMenu = WindowApis.GetSystemMenu(hWnd, false);
			if (hMenu == IntPtr.Zero)
				return;

			var enabled = isEnabled ? ApiConstants.MF_BYCOMMAND | ApiConstants.MF_ENABLED :
									  ApiConstants.MF_BYCOMMAND | ApiConstants.MF_GRAYED;

			WindowApis.EnableMenuItem(hMenu, (uint)menuItem, enabled);
		}
	}
}
