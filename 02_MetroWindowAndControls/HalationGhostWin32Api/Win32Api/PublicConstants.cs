using System;

namespace HalationGhost.Win32Api
{
	public enum SystemMenuItem
	{
		SizeItem = (int)ApiConstants.SC_SIZE,
		/// <summary>移動メニュー項目を表します。</summary>
		MoveItem = (int)ApiConstants.SC_MOVE,
		/// <summary>最小化メニュー項目を表します。</summary>
		MinimizeItem = (int)ApiConstants.SC_MINIMIZE,
		/// <summary>最大化メニュー項目を表します。</summary>
		MaxmizeItem = (int)ApiConstants.SC_MAXIMIZE,
		/// <summary>閉じるメニュー項目を表します。</summary>
		CloseItem = (int)ApiConstants.SC_CLOSE
	}

	[Flags]
	public enum MetroWindowStyle
	{
		/// <summary>最大化を許可します。</summary>
		CanMaxmize = (int)ApiConstants.WS_MAXIMIZEBOX,
		/// <summary>最小化を許可します。</summary>
		CanMinimize = (int)ApiConstants.WS_MINIMIZEBOX,
		/// <summary>システムメニューを表示します。</summary>
		ShowSystemMenu = (int)ApiConstants.WS_SYSMENU
	}

	public static class WindowsApiConstants
	{
		//--- Window Message
		public const int WM_SIZE = 0x5;
		public const int WM_SYSCOMMAND = 0x0112;
		public const int WM_INITMENU = 0x0116;
		public const int WM_NCLBUTTONDBLCLK = 0xA3;

		public const int SIZE_RESTORED = 0x0;
		public const int SIZE_MINIMIZED = 0x1;
		public const int SIZE_MAXIMIZED = 0x2;
	}
}
