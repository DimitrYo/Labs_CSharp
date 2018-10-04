using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using IMS.SMS.GUI;

namespace IMS.SMS.Filter.GUI {
    public class SmsStorage : IModel {
        public event ModelHandler<SmsStorage> changed;
        private object LockMsgTextList;
        public event Func<Message, Message> FormatterMsgEvent;
        private SmsProvider SMSProvider;

        public string UserToFilter { get; set; }
        public string TextToFilter { get; set; }
        public DateTime MinDateTimeToFilter { get; set; }
        public DateTime MaxDateTimeToFilter { get; set; }
        public string StyleMessage { get; set; }
        public bool FilterByMaxDateChecked { get; set; }
        public bool FilterByMinDateChecked { get;  set; }
        public List<Message> MsgTextListGet { get; }

        public SmsStorage() {
            SMSProvider = new SmsProvider();
            MsgTextListGet = new List<Message>();
            SMSProvider.SMSReceivedMsg += OnSmsReceivedMsg;
            LockMsgTextList = new object();
        }

        public void OnSmsReceivedMsg(Message msg) {
            msg = FormatterMsgEvent?.Invoke(msg) ?? msg;

            lock (LockMsgTextList) {
                MsgTextListGet.Add(msg);
            }

            UpdateView();
        }

        public void StartTimer() {
            SMSProvider.ThreadingTimerStartMsg();
        }

        public void StopTimer() {
            SMSProvider.ThreadingTimerStop();
        }

        public void AttachIModelObserver(IModelObserver imo) {
            changed += new ModelHandler<SmsStorage>(imo.MessageBoxUpdate);
        }
        public bool IsSubscribedAttachIModelObserver() {
            return changed.GetInvocationList().Count() > 0;
        }

        public void ViewChanged(ViewEventArgs e) {
            UserToFilter = e.UserToFilter;
            TextToFilter = e.TextToFilter;
            MinDateTimeToFilter = e.MinDateTimeToFilter;
            MaxDateTimeToFilter = e.MaxDateTimeToFilter;
            StyleMessage = e.StyleMessage;
            FilterByMinDateChecked = e.FilterByMinDateChecked;
            FilterByMaxDateChecked = e.FilterByMaxDateChecked;

            UpdateView();
        }

        public void UpdateView() {
            List<Message> temp;
            lock (LockMsgTextList) {
                temp = new List<Message>(MsgTextListGet);
            }
            if (temp != null) {
                var messages = FilterByUser(temp);
                messages = FilterByMinDateTime(messages);
                messages = FilterByMaxDateTime(messages);
                messages = FilterByText(messages);
                StyleChanged();
                changed?.BeginInvoke(this, new ModelEventArgs((List<Message>)messages.ToList()), null, null);
            }

        }

        public void StyleChanged() {
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

        public bool FormatterMsgEventIsSubscribed(Func<Message, Message> d) {
            return FormatterMsgEvent.GetInvocationList().Contains(d);
        }

        public void AttachOnlyOneHandler(Func<Message, Message> handler) {
            if (FormatterMsgEvent != null) {
                foreach (var del in FormatterMsgEvent.GetInvocationList()) {
                    FormatterMsgEvent -= (Func<Message, Message>)del;
                }
            }
            FormatterMsgEvent += handler;
        }

        public IEnumerable<Message> FilterByMaxDateTime(IEnumerable<Message> messages) {
            if (MaxDateTimeToFilter != null && FilterByMaxDateChecked) {
                messages = messages.Where(m => m.ReceivingTime <= MaxDateTimeToFilter);
            }
            return messages;
        }

        public IEnumerable<Message> FilterByMinDateTime(IEnumerable<Message> messages) {
            if (MinDateTimeToFilter != null && FilterByMinDateChecked) {
                messages = messages.Where(m => m.ReceivingTime >= MinDateTimeToFilter);
            }
            return messages;
        }

        public IEnumerable<Message> FilterByUser(IEnumerable<Message> messages) {
            if (UserToFilter != null) {
                messages = messages.Where(m => m.User.Equals(UserToFilter));
            }
            return messages;
        }

        public IEnumerable<Message> FilterByText(IEnumerable<Message> messages) {
            if (TextToFilter != null) {
                messages = messages.Where(s => s.ToString().Contains(TextToFilter));
            }
            return messages;
        }
    }
}