using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Hook
{
    class Hook
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        [DllImport("user32.dll", SetLastError = true)]
        protected static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);
                                                                                                                                                                                                                                                                                                                        [DllImport("user32.dll")]
        protected static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam,
          IntPtr lParam);
                                                                                                                                                                                                                                                                                                                                                        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        protected static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
        protected static extern IntPtr GetModuleHandle(IntPtr lpModule);
        [DllImport("kernel32.dll")]
        protected static extern uint GetCurrentThreadId();
        
        protected IntPtr HookHandle;


        protected bool SetHook(HookType type, HookProc proc, bool isGlobal)
        {
            uint threadId = isGlobal ? 0 : GetCurrentThreadId();
            HookHandle = SetWindowsHookEx(type, proc, GetModuleHandle(new IntPtr(0)), threadId);
            return !HookHandle.Equals(new IntPtr(0));
        }

        public virtual bool SetHook()
        {
            return false;
        }
        
        public virtual bool UnHook()
        {
            return UnhookWindowsHookEx(HookHandle);
        }
    }
    public struct HookMsg
    {
        public IntPtr message;
        public IntPtr paramL;
        public IntPtr paramH;
        public IntPtr time;
        public IntPtr hwnd;
        public override string ToString()
        {
            return string.Format("message:{0},paramL:{1},ParamH:{2},time:{3},hwnd:{4}", message, paramL, paramH, time,
                hwnd);
        }
    }

                public enum HookType : int
    {
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

    public enum MouseMsg
    {
        WM_LBUTTONDBLCLK = 515,
        WM_LBUTTONDOWN = 513,
        WM_LBUTTONUP = 514,
        WM_MBUTTONDBLCLK = 521,
        WM_MBUTTONDOWN = 519,
        WM_MBUTTONUP = 520,
        WM_RBUTTONDBLCLK=518,
        WM_RBUTTONDOWN=516,
        WM_RBUTTONUP=517,
        WM_MOUSEMOVE=512,
        WM_MOUSEWHEEL=523
    }
}
