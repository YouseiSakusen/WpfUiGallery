using System;
using System.Collections.Generic;
using System.Text;

namespace HalationGhost.Win32Api
{
	internal class ApiConstants
	{
		//--- GetWindowLong
		internal const int GWL_STYLE = -16;

		//--- Window Style
		internal const int WS_MAXIMIZEBOX = 0x10000;
		internal const int WS_MINIMIZEBOX = 0x20000;
		internal const int WS_SYSMENU = 0x80000;

		internal const UInt32 SC_SIZE = 0xF000;
		internal const UInt32 SC_MOVE = 0xF010;
		internal const UInt32 SC_MINIMIZE = 0xF020;
		internal const UInt32 SC_MAXIMIZE = 0xF030;
		internal const UInt32 SC_NEXTWINDOW = 0xF040;
		internal const UInt32 SC_PREVWINDOW = 0xF050;
		internal const UInt32 SC_CLOSE = 0xF060;

		//--- Virtual Keyboard
		internal const int VK_F4 = 0x73;

		// メニューフラグ
		internal const uint MF_BYCOMMAND = 0x00000000;
		internal const uint MF_GRAYED = 0x00000001;
		internal const uint MF_ENABLED = 0x00000000;
	}
}
