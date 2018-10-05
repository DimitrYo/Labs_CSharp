using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.SMS.Charger.GUI {

    public class BatteryProgressBar : ProgressBar {

        public override void Refresh() {
            //((ProgressBar)this).Refresh();

            using (Graphics gr = this.CreateGraphics()) {
                gr.DrawString(this.Value.ToString() + "%",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(this.Width / 2 - (gr.MeasureString(this.Value.ToString() + "%",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    this.Height / 2 - (gr.MeasureString(this.Value.ToString() + "%",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
            UpdateBatteryProgressbarColor();
        }

        private void UpdateBatteryProgressbarColor() {
            var chargeLevel = this.Value;
            if (chargeLevel > 30) {
                ModifyProgressBarColor.SetState(this, 1);
            } else {
                if (chargeLevel > 10) {
                    ModifyProgressBarColor.SetState(this, 3);
                } else {
                    ModifyProgressBarColor.SetState(this, 2);
                }
            }
        }
    }
}
