using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS.Contacts.GUI {
    public partial class CallsApp : Form, ICallView {
        public CallsApp() {
            InitializeComponent();
        }

        IController cnt;

        public event CallViewHandler<ICallView> Changed;

        public void setCallController(IController cont) {
            this.cnt = cont;
        }
    }
}
