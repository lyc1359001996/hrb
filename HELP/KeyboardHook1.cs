﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Hook
{
    class KeyboardHook1 : Hook
    {
        public override bool SetHook()
        {
            return base.SetHook(HookType.WH_KEYBOARD_LL, KeyboardHookProc, true);
        }

        private IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            IntPtr nextHandle = CallNextHookEx(HookHandle, code, wParam, lParam); /*Call下一个钩子*/
            HookMsg hMsg = (HookMsg)Marshal.PtrToStructure(lParam, typeof(HookMsg));
            Keys key = (Keys)hMsg.message.ToInt32();
            Console.WriteLine("[键盘Hook] 按下的键:{0}", key);
            if (!key.Equals(Keys.Escape))
            {
                //拦截某些键
                nextHandle = new IntPtr(1); /*返回1，吃掉消息,否则返回CallNextHookEx*/
            }
            return nextHandle;
        }

    }


}