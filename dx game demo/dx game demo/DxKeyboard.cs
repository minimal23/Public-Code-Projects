using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;

namespace dx_game_demo
{
    class DxKeyboard
    {
        protected Device keyboard = null;
        public DxKeyboard(Control ctrl)
        {
            keyboard = new Device(SystemGuid.Keyboard);
            keyboard.SetDataFormat(DeviceDataFormat.Keyboard);
            keyboard.SetCooperativeLevel(ctrl,
                CooperativeLevelFlags.Foreground |
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.NoWindowsKey);
        }
        public KeyboardState GetkeyboardState()
        {
            KeyboardState state = null;
            do
            {
                try
                {
                    state = this.keyboard.GetCurrentKeyboardState();
                    if (state != null)
                    {
                        break;
                    }
                }
                catch (InputException)
                {
                    Application.DoEvents();
                    try
                    {
                        keyboard.Acquire();
                    }
                    catch (InputLostException)
                    {
                        continue;
                    }
                    catch (OtherApplicationHasPriorityException)
                    {
                        continue;
                    }
                }
            }
            while (true);
            return state;
        }
    }
}
