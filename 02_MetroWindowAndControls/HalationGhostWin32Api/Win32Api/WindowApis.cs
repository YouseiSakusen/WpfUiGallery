using System;
using System.Runtime.InteropServices;

namespace HalationGhost.Win32Api
{
	/// <summary>Win32APIラッパーを表します。</summary>
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

		/// <summary>WindowのStyleを変更します。</summary>
		/// <param name="hWnd">ウィンドウハンドルを表すIntPtr。</param>
		/// <param name="styleFlag">Windowに設定するStyleを表すMetroWindowStyle列挙型フラグ。</param>
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

		/// <summary>システムメニュー項目の有効/無効を設定します。</summary>
		/// <param name="hWnd">対象のウィンドウハンドルを表すIntPtr。</param>
		/// <param name="menuItem">システムメニュー項目を表すSystemMenuItem列挙型の内の1つ</param>
		/// <param name="isEnabled">設定する有効状態を表すbool。</param>
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
