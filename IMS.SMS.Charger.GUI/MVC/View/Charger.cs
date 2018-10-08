using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.SMS.GUI;
using Message = IMS.SMS.GUI.Message;
using System.Linq;
using IMS.SMS.Filter.GUI;
using System.Drawing;

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
            this.batteryProgresBar.Style = ProgressBarStyle.Continuous;
            this.IsCharging = false;
        }

        IController filterSmsController;
        IController chargerController;

        public bool IsCharging { get; private set; }

        public event ViewSmsHandler<IView> Changed;
        public event ViewBatteryHandler<IBatteryView> ChangedProgressBar;

        public void setfilterSmsController(IController cont) {
            filterSmsController = cont;
        }

        public void setChargeController(BatteryController cont) {
            chargerController = cont;
        }

        private void startButton_Click(object sender, EventArgs e) {
            filterSmsController.Start();
        }

        private void stopButton_Click(object sender, EventArgs e) {
            filterSmsController.Stop();
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
            UpdateSmsStorage();
            UpdateBattery();
        }

        private void UpdateBattery() {
            var batteryArg = new ViewBatteryEventArgs {
                IsCharging = this.IsCharging
            };

            ChangedProgressBar?.BeginInvoke(this, batteryArg, null, null);
        }

        private void UpdateSmsStorage() {
            var viewArg = new ViewEventArgs(userComboBox?.SelectedItem?.ToString(), searchTextBox.Text,
                dateTimePickerMin.Value, dateTimePickerMax.Value,
                formattingComboBox?.SelectedItem?.ToString(),
                dateTimePickerMin.Checked, dateTimePickerMax.Checked);

            Changed?.Invoke(this, viewArg);
        }

        private void userComboBox_TextChanged(object sender, EventArgs e) {
            Update();
        }

        public void BatteryProgressBarUpdate(IBatteryModel model, BatteryModelEventArgs e) {
            if (InvokeRequired) {
                batteryProgresBar?.BeginInvoke(new Action<IBatteryModel, BatteryModelEventArgs>(BatteryProgressBarUpdate), model, e);
            } else {
                batteryProgresBar.Value = e.ChargeLevelInt;
                batteryProgresBar?.Refresh();
            }
        }

        private void chargeButton_Click(object sender, EventArgs e) {

            this.IsCharging = !this.IsCharging;

            var arg = new ViewBatteryEventArgs {
                IsCharging = this.IsCharging
            };

            if (IsCharging) {
                chargeButton.Text = "Disconnect charge";
            } else {
                chargeButton.Text = "Connect charge";
            }

            ChangedProgressBar?.BeginInvoke(this, arg, null, null);
        }
    }
}
