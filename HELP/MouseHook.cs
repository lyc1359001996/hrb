﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Hook
{
    class MouseHook : Hook
    {
        public override bool SetHook()
        {
            return base.SetHook(HookType.WH_MOUSE_LL, MouseHookProc, true);
        }

        private IntPtr MouseHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            IntPtr nextHandle = CallNextHookEx(HookHandle, code, wParam, lParam); /*Call下一个钩子*/
            MouseMsg mouseMsg = (MouseMsg)wParam;
            MouseButtons mouse;
            switch (mouseMsg)
            {
                case MouseMsg.WM_LBUTTONDOWN:
                case MouseMsg.WM_LBUTTONUP:
                    mouse = MouseButtons.Left;
                    break;
                case MouseMsg.WM_MBUTTONDOWN:
                case MouseMsg.WM_MBUTTONUP:
                    mouse=MouseButtons.Middle;
                    break;
                case MouseMsg.WM_RBUTTONDOWN:
                case MouseMsg.WM_RBUTTONUP:
                    mouse=MouseButtons.Right;
                    break;
                default:
                    mouse = MouseButtons.None;
                    break;
            }
            if (mouse.Equals(MouseButtons.Right))
            {
                nextHandle=new IntPtr(1);
            }
            return nextHandle;
        }
    }
}
