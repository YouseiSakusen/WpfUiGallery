using System;
using System.Collections.Generic;
using System.Text;

namespace HalationGhost.Win32Api
{
	public class ApiConstants
	{
		//--- GetWindowLong
		public const int GWL_STYLE = -16;
		//--- Window Style
		public const int WS_SYSMENU = 0x80000;

		//--- Window Message
		public const int WM_SYSKEYDOWN = 0x0104;
		public const int WM_SYSCOMMAND = 0x0112;

		public const long SC_CLOSE = 0xF060L;

		//--- Virtual Keyboard
		public const int VK_F4 = 0x73;
	}
}
