using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.SMS.GUI;
using Message = IMS.SMS.GUI.Message;
using System.Linq;

namespace IMS.SMS.Filter.GUI {
    public partial class SmsFilter : Form {
        public SmsFilter() {
            InitializeComponent();
            SetupHandlers();
        }


        public event Func<Message, Message> FormatterMsgEvent;
        readonly object someEventLock = new object();
        private SmsProvider SMSProvider = new SmsProvider();
        private List<Message> MsgTextList = new List<Message>();

        private void SetupHandlers() {
            //
            // SmsProvider
            //
            this.SMSProvider.SMSReceivedMsg += OnSmsReceivedMsg;
            this.SMSProvider.ThreadingTimerStartMsg();
        }

        public void OnSmsReceivedMsg(Message msg) {
            lock (someEventLock) {
                if (InvokeRequired) {
                    this?.BeginInvoke(new Action<Message>(OnSmsReceivedMsg), msg);
                } else {
                    msg = FormatterMsgEvent?.Invoke(msg) ?? msg;
                    MsgTextList.Add(msg);
                    OnUserChange();
                    MessageBoxUpdate();
                }
            }
        }

        private void OnUserChange() {
            var selIndex = userComboBox.SelectedIndex;
            userComboBox.Items.Clear();
            userComboBox.Items.AddRange(MsgTextList.Select(m => m.User).Distinct().ToArray());
            userComboBox.SelectedIndex = selIndex;
        }

        private void MessageBoxUpdate() {
            var messages = MsgTextList;

            messages = FilterByUser(messages);

            messages = FilterByMinDateTime(messages);

            messages = FilterByMaxDate(messages);

            IEnumerable<string> temp = messages.Select(el => el.ToString());

            temp = FilterByContainedString(temp);

            MessageBox.Lines = temp.ToArray();
        }

        private IEnumerable<string> FilterByContainedString(IEnumerable<string> temp) {
            if (this.searchTextBox.Text.Length > 0) {
                temp = temp.Where(s => s.Contains(this.searchTextBox.Text));
            }

            return temp;
        }

        private List<Message> FilterByMaxDate(List<Message> messages) {
            if (dateTimePickerMax.Checked) {
                messages = messages.Where(m => m.ReceivingTime <= dateTimePickerMax.Value).ToList();
            }

            return messages;
        }

        private List<Message> FilterByMinDateTime(List<Message> messages) {
            if (dateTimePickerMin.Checked) {
                messages = messages.Where(m => m.ReceivingTime >= dateTimePickerMin.Value).ToList();
            }

            return messages;
        }

        private List<Message> FilterByUser(List<Message> messages) {
            if (this.userComboBox.SelectedItem != null) {
                messages = messages.Where(m => m.User.Equals(userComboBox.SelectedItem.ToString())).ToList();
            }

            return messages;
        }

        public string GetLastTestMessageBox(Object obj) {
            lock (someEventLock) {
                var items = MessageBox.Lines;
                return items[items.Length - 1];
            }
        }

        public void FormattingComboBox_SelectedIndexChangedEmulate(int index) {
            FormattingComboBox.SelectedItem = index;
        }

        private void FormattingComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            var item = FormattingComboBox.SelectedItem;

            switch (item) {

                case "None":
                AttachOnlyOneHandler(null);
                AttachOnlyOneHandler(null);
                break;

                case "Start with DateTime":
                AttachOnlyOneHandler(Message.FormatWithDateTimeOnStart);
                break;

                case "End with DateTime":
                AttachOnlyOneHandler(Message.FormatWithDateTimeOnEnd);
                break;

                case "Lowercase":
                AttachOnlyOneHandler(Message.FormatLowerCase);
                break;

                case "Uppercase":
                AttachOnlyOneHandler(Message.FormatUpperCase);
                break;
            }
        }

        public void AttachOnlyOneHandler(Func<Message, Message> handler) {
            lock (someEventLock) {
                if (FormatterMsgEvent != null) {
                    foreach (var del in FormatterMsgEvent.GetInvocationList()) {
                        FormatterMsgEvent -= (Func<Message, Message>)del;
                    }
                }
                FormatterMsgEvent += handler;
            }
        }

        private void userComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            MessageBoxUpdate();
        }

        private void startButton_Click(object sender, System.EventArgs e) {
            this.SMSProvider.ThreadingTimerStartMsg();
        }

        private void stopButton_Click(object sender, System.EventArgs e) {
            this.SMSProvider.ThreadingTimerStop();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) {
            MessageBoxUpdate();
        }

        private void dateTimePickerMax_ValueChanged(object sender, EventArgs e) {
            MessageBoxUpdate();
        }

        private void dateTimePickerMin_ValueChanged(object sender, EventArgs e) {
            MessageBoxUpdate();
        }
    }
}
