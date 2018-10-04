using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.SMS.GUI;
using Message = IMS.SMS.GUI.Message;
using System.Linq;
using IMS.SMS.Filter.GUI;

namespace IMS.SMS.Charger.GUI {
    public partial class Charger : Form, IView, IModelObserver, IBatteryView, IModelBatteryObserver {
        public Charger() {
            InitializeComponent();
            SetuoInitialValues();
        }

        private void SetuoInitialValues() {
            this.dateTimePickerMin.Value = DateTime.Now;
            this.dateTimePickerMax.Value = this.dateTimePickerMin.Value + TimeSpan.FromSeconds(5);
            this.formattingComboBox.SelectedIndex = 0;
        }

        IController filterSmsController;
        public event ViewHandler<IView> changed;
        public event ViewBatteryHandler<IBatteryView> changedProgressBar;

        public void setfilterSmsController(IController cont) {
            filterSmsController = cont;
        }

        private void startButton_Click(object sender, EventArgs e) {
            filterSmsController.StartTimer();
        }

        private void stopButton_Click(object sender, EventArgs e) {
            filterSmsController.StopTimer();
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
                formattingComboBox?.SelectedItem?.ToString(),
                dateTimePickerMin.Checked, dateTimePickerMax.Checked);

            changed?.Invoke(this, viewArg);
        }

        private void userComboBox_TextChanged(object sender, EventArgs e) {
            Update();
        }

        public void BatteryProgressBarUpdate(IBatteryModel model, BatteryModelEventArgs e) {
            if (InvokeRequired) {
                batteryProgresBar?.BeginInvoke(new Action<IBatteryModel, BatteryModelEventArgs>(BatteryProgressBarUpdate), model, e);
            } else {
                //var messages = e.MsgTextList.AsEnumerable().Select(el => el.ToString()).ToArray();
                // TODO
            }
        }

        public void BatteryProgressbarUpdate(IBatteryModel model, BatteryModelEventArgs e) {
            throw new NotImplementedException();
        }
    }
}
