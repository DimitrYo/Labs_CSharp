using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IMS.SMS.Charger.GUI {
    public static class ModifyProgressBarColor {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this BatteryProgressBar pBar, int state) {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
