using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.SMS.GUI;

namespace IMS.SMS.Filter.GUI {
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);

    public class ModelEventArgs : EventArgs {
        public List<Message> MsgTextList { get; }

        public ModelEventArgs(List<Message> messages) {
            MsgTextList = messages;
        }
    }

    public interface IModelObserver {
        void MessageBoxUpdate2(IModel model, ModelEventArgs e);
    }
 
    public interface IModel {

        void SetupHandlers();
        void OnSmsReceivedMsg(Message msg);
        void StartTimer();
        void StopTimer();
        void attachIModelObserver(IModelObserver view);
    }

    public class SmsStorage : IModel {
        public event Func<Message, Message> FormatterMsgEvent;
        private SmsProvider SMSProvider = new SmsProvider();
        private List<Message> MsgTextList = new List<Message>();

        public event ModelHandler<SmsStorage> changed;

        public SmsStorage() {

            SetupHandlers();
        }

        public void SetupHandlers() {
            //
            // SmsProvider
            //
            SMSProvider.SMSReceivedMsg += OnSmsReceivedMsg;
            StartTimer();
        }

        public void OnSmsReceivedMsg(Message msg) {
                msg = FormatterMsgEvent?.Invoke(msg) ?? msg;
                MsgTextList.Add(msg);
                changed.Invoke(this, new ModelEventArgs(MsgTextList));
        }


        public void StartTimer() {
            SMSProvider.ThreadingTimerStartMsg();
        }

        public void StopTimer() {
            SMSProvider.ThreadingTimerStop();
        }

        public void attachIModelObserver(IModelObserver imo) {
            changed += new ModelHandler<SmsStorage>(imo.MessageBoxUpdate2);
        }
    }
}