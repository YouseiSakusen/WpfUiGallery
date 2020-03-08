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

		#endregion

		public static void ChangeSystemMenuVisible(IntPtr hwnd, bool visible)
		{
			var style = WindowApis.GetWindowLong(hwnd, ApiConstants.GWL_STYLE);
			if (visible)
				style |= ApiConstants.WS_SYSMENU;
			else
				style &= ~ApiConstants.WS_SYSMENU;

			WindowApis.SetWindowLong(hwnd, ApiConstants.GWL_STYLE, style);
		}
	}
}
