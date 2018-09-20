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
        public SmsForm( ) {
            InitializeComponent();
            SetupHandlers();
        }
    }
}
