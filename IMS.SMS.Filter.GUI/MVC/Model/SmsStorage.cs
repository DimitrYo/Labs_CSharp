using System;
using System.Collections.Generic;
using System.Linq;
using IMS.SMS.GUI;

namespace IMS.SMS.Filter.GUI {
    public class SmsStorage : IModel {
        public event Func<Message, Message> FormatterMsgEvent;
        private SmsProvider SMSProvider;
        private List<Message> MsgTextList;
        private string UserToFilter { get; set; }
        private string TextToFilter { get; set; }
        private DateTime MinDateTimeToFilter { get; set; }
        private DateTime MaxDateTimeToFilter { get; set; }
        public string StyleMessage { get; private set; }
        public bool FilterByDateChecked { get; private set; }
        public bool FilterByMaxDateChecked { get; private set; }
        public bool FilterByMinDateChecked { get; private set; }

        public event ModelHandler<SmsStorage> changed;

        private object LockMsgTextList;

        public SmsStorage() {
            SMSProvider = new SmsProvider();
            MsgTextList = new List<Message>();
            SMSProvider.SMSReceivedMsg += OnSmsReceivedMsg;
            LockMsgTextList = new object();
        }

        public void OnSmsReceivedMsg(Message msg) {
            msg = FormatterMsgEvent?.Invoke(msg) ?? msg;

            lock (LockMsgTextList) {
                MsgTextList.Add(msg);
            }

            UpdateView();
        }

        public void StartTimer() {
            SMSProvider.ThreadingTimerStartMsg();
        }

        public void StopTimer() {
            SMSProvider.ThreadingTimerStop();
        }

        public void attachIModelObserver(IModelObserver imo) {
            changed += new ModelHandler<SmsStorage>(imo.MessageBoxUpdate);
        }

        public void viewChanged(ViewEventArgs e) {
            UserToFilter = e.UserToFilter;
            TextToFilter = e.TextToFilter;
            MinDateTimeToFilter = e.MinDateTimeToFilter;
            MaxDateTimeToFilter = e.MaxDateTimeToFilter;
            StyleMessage = e.StyleMessage;
            FilterByMinDateChecked = e.FilterByMinDateChecked;
            FilterByMaxDateChecked = e.FilterByMaxDateChecked;

            UpdateView();
        }

        private void UpdateView() {
            List<Message> temp;
            lock (LockMsgTextList) {
                temp = new List<Message>(MsgTextList);
            }
            if (temp != null ) {
                var messages = FilterByUser(temp);
                messages = FilterByMinDateTime(messages);
                messages = FilterByMaxDateTime(messages);
                messages = FilterByContainedString(messages);
                StyleChanged();
                changed?.BeginInvoke(this, new ModelEventArgs((List<Message>)messages.ToList()), null, null);
            }

        }

        private void StyleChanged() {
            switch (StyleMessage) {

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
            if (FormatterMsgEvent != null) {
                foreach (var del in FormatterMsgEvent.GetInvocationList()) {
                    FormatterMsgEvent -= (Func<Message, Message>)del;
                }
            }
            FormatterMsgEvent += handler;
        }

        private IEnumerable<Message> FilterByMaxDateTime(IEnumerable<Message> messages) {
            if (MaxDateTimeToFilter != null && FilterByMaxDateChecked) {
                messages = messages.Where(m => m.ReceivingTime <= MaxDateTimeToFilter);
            }
            return messages;
        }

        private IEnumerable<Message> FilterByMinDateTime(IEnumerable<Message> messages) {
            if (MinDateTimeToFilter != null && FilterByMinDateChecked) {
                messages = messages.Where(m => m.ReceivingTime >= MinDateTimeToFilter);
            }
            return messages;
        }

        private IEnumerable<Message> FilterByUser(IEnumerable<Message> messages) {
            if (UserToFilter != null) {
                messages = messages.Where(m => m.User.Equals(UserToFilter));
            }
            return messages;
        }

        private IEnumerable<Message> FilterByContainedString(IEnumerable<Message> messages) {
            if (TextToFilter != null) {
                messages = messages.Where(s => s.ToString().Contains(TextToFilter));
            }
            return messages;
        }
    }
}