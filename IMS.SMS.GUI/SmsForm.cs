using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.SMS.GUI {
    public partial class SmsForm : Form {
        public SmsForm() {
            InitializeComponent();
        }

        private void FormattingComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            var item = FormattingComboBox.SelectedItem;

            switch (item) {

                case "None":
                    AttachOnlyOneHandler(null);
                    AttachOnlyOneHandler(null);
                    break;

                case "Start with DateTime":
                    AttachOnlyOneHandler(FormatWithDateTimeOnStart);
                    break;

                case "End with DateTime":
                    AttachOnlyOneHandler(FormatWithDateTimeOnEnd);
                    break;

                case "Lowercase":
                    AttachOnlyOneHandler(FormatLowerCase);
                    break;

                case "Uppercase":
                    AttachOnlyOneHandler(FormatUpperCase);
                    break;
            }
        }

        private void AttachOnlyOneHandler(Func<string, string> handler) {
            lock (someEventLock) {
                if (Formatter != null) {
                    foreach (var del in Formatter.GetInvocationList()) {
                        Formatter -= (Func<string, string>)del;
                    }
                }
                Formatter += handler;
            }
        }
    }
}
