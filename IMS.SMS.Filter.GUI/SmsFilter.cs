﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IMS.SMS.GUI;
using Message = IMS.SMS.GUI.Message;
using System.Linq;

namespace IMS.SMS.Filter.GUI {
    public partial class SmsFilter : Form, IView, IModelObserver {
        public SmsFilter() {
            InitializeComponent();
            SetupHandlers();
        }


        public event Func<Message, Message> FormatterMsgEvent;
        //readonly object someEventLock = new object();
        //private SmsProvider SMSProvider = new SmsProvider();
        //private List<Message> MsgTextList = new List<Message>();

        IController controller;
        public event ViewHandler<IView> changed;
        // View will set the associated controller, this is how view is linked to the controller.
        public void setController(IController cont) {
            controller = cont;
        }


        private void SetupHandlers() {
            //
            // SmsProvider
            //
            //this.SMSProvider.SMSReceivedMsg += OnSmsReceivedMsg;
            controller?.StartTimer();
        }

        //public void OnSmsReceivedMsg(Message msg) {
        //    lock (someEventLock) {
        //        if (InvokeRequired) {
        //            this?.BeginInvoke(new Action<Message>(OnSmsReceivedMsg), msg);
        //        } else {
        //            msg = FormatterMsgEvent?.Invoke(msg) ?? msg;
        //            MsgTextList.Add(msg);
        //            OnUserChange();
        //            MessageBoxUpdate();
        //        }
        //    }
        //}

        private void OnUserChange() {
            //var selIndex = userComboBox.SelectedIndex;
            //userComboBox.Items.Clear();
            //userComboBox.Items.AddRange(MsgTextList.Select(m => m.User).Distinct().ToArray());
            //userComboBox.SelectedIndex = selIndex;
        }


        public void MessageBoxUpdate2(IModel m, ModelEventArgs e) {
            if (InvokeRequired) {
                MessageBox?.BeginInvoke(new Action<IModel,ModelEventArgs>(MessageBoxUpdate2),m,e);
            } else {
                var messages = e.MsgTextList.AsEnumerable();

                //messages = FilterByUser(messages);

                //messages = FilterByMinDateTime(messages);

                //messages = FilterByMaxDate(messages);

                IEnumerable<string> temp = messages.Select(el => el.ToString());

                temp = FilterByContainedString(temp);
                MessageBox.Lines = temp.ToArray();
            }            
        }

        private void MessageBoxUpdate() {
            //IEnumerable<string> temp = UpdateView();

            //MessageBox.Lines = temp.ToArray();
        }

        //private IEnumerable<string> UpdateView() {
        //    var messages = MsgTextList.AsEnumerable();

        //    messages = FilterByUser(messages);

        //    messages = FilterByMinDateTime(messages);

        //    messages = FilterByMaxDate(messages);

        //    IEnumerable<string> temp = messages.Select(el => el.ToString());

        //    temp = FilterByContainedString(temp);
        //    return temp;
        //}

        private IEnumerable<Message> FilterByMaxDate(IEnumerable<Message> messages) {
            if (dateTimePickerMax.Checked) {
                messages = messages.Where(m => m.ReceivingTime <= dateTimePickerMax.Value).ToList();
            }

            return messages;
        }

        private IEnumerable<Message> FilterByMinDateTime(IEnumerable<Message> messages) {
            if (dateTimePickerMin.Checked) {
                messages = messages.Where(m => m.ReceivingTime >= dateTimePickerMin.Value).ToList();
            }

            return messages;
        }

        private IEnumerable<Message> FilterByUser(IEnumerable<Message> messages) {
            if (this.userComboBox.SelectedItem != null) {
                messages = messages.Where(m => m.User.Equals(userComboBox.SelectedItem.ToString()));
            }

            return messages;
        }

        private IEnumerable<string> FilterByContainedString(IEnumerable<string> temp) {
            if (this.searchTextBox.Text.Length > 0) {
                temp = temp.Where(s => s.Contains(this.searchTextBox.Text));
            }

            return temp;
        }

        public string GetLastTestMessageBox(Object obj) {
                var items = MessageBox.Lines;
                return items[items.Length - 1];
        }

        public void FormattingComboBox_SelectedIndexChangedEmulate(int index) {
            FormattingComboBox.SelectedItem = index;
        }

        private void FormattingComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //var item = FormattingComboBox.SelectedItem;

            //switch (item) {

            //    case "None":
            //    AttachOnlyOneHandler(null);
            //    AttachOnlyOneHandler(null);
            //    break;

            //    case "Start with DateTime":
            //    AttachOnlyOneHandler(Message.FormatWithDateTimeOnStart);
            //    break;

            //    case "End with DateTime":
            //    AttachOnlyOneHandler(Message.FormatWithDateTimeOnEnd);
            //    break;

            //    case "Lowercase":
            //    AttachOnlyOneHandler(Message.FormatLowerCase);
            //    break;

            //    case "Uppercase":
            //    AttachOnlyOneHandler(Message.FormatUpperCase);
            //    break;
            //}
        }

        public void AttachOnlyOneHandler(Func<Message, Message> handler) {
                if (FormatterMsgEvent != null) {
                    foreach (var del in FormatterMsgEvent.GetInvocationList()) {
                        FormatterMsgEvent -= (Func<Message, Message>)del;
                    }
                FormatterMsgEvent += handler;
            }
        }

        //private void userComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
        //    MessageBoxUpdate();
        //}

        private void startButton_Click(object sender, System.EventArgs e) {
            controller.StartTimer();
        }

        private void stopButton_Click(object sender, System.EventArgs e) {
            controller.StopTimer();
        }

        //private void searchTextBox_TextChanged(object sender, EventArgs e) {
        //    MessageBoxUpdate();
        //}

        //private void dateTimePickerMax_ValueChanged(object sender, EventArgs e) {
        //    MessageBoxUpdate();
        //}

        //private void dateTimePickerMin_ValueChanged(object sender, EventArgs e) {
        //    MessageBoxUpdate();
        //}
    }
}
