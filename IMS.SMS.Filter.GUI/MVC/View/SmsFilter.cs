using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.SMS.GUI;
using Message = IMS.SMS.GUI.Message;
using System.Linq;

namespace IMS.SMS.Filter.GUI {
    public partial class SmsFilter : Form, IView, IModelObserver {
        public SmsFilter() {
            InitializeComponent();
            SetuoInitialValues();
        }

        private void SetuoInitialValues() {
            this.dateTimePickerMin.Value = DateTime.Now;
            this.dateTimePickerMax.Value = this.dateTimePickerMin.Value + TimeSpan.FromSeconds(5);
            this.FormattingComboBox.SelectedIndex = 0;
        }

        IController controller;
        public event ViewHandler<IView> changed;
        public void setfilterSmsController(IController cont) {
            controller = cont;
        }

        private void startButton_Click(object sender, EventArgs e) {
            controller.Start();
        }

        private void stopButton_Click(object sender, EventArgs e) {
            controller.Stop();
        }

        public void MessageBoxUpdate(IModel m, ModelEventArgs e) {
            if (InvokeRequired) {
                SmsMessageBox?.BeginInvoke(new Action<IModel, ModelEventArgs>(MessageBoxUpdate), m, e);
            } else {
                var messages = e.MsgTextList.AsEnumerable().Select(el => el.ToString()).ToArray();

                OnSmsDataChangedUpdateMsgBox(messages);
            }
        }

        private void OnSmsDataChangedUpdateMsgBox(string[] messages) {
            SmsMessageBox.Lines = messages;
        }

        private void FormattingComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Update();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) {
            Update();
        }

        private void dateTimePickerMax_ValueChanged(object sender, EventArgs e) {
            Update();
        }

        private void dateTimePickerMin_ValueChanged(object sender, EventArgs e) {
            Update();
        }

        private void SmsFilter_Load(object sender, EventArgs e) {
            Update();
        }

        public new void Update() {
            var viewArg = new ViewEventArgs(userComboBox?.SelectedItem?.ToString(), searchTextBox.Text,
                dateTimePickerMin.Value, dateTimePickerMax.Value,
                FormattingComboBox?.SelectedItem?.ToString(),
                dateTimePickerMin.Checked, dateTimePickerMax.Checked);

            changed?.Invoke(this, viewArg);
        }

        private void userComboBox_TextChanged(object sender, EventArgs e) {
            Update();
        }
    }
}
