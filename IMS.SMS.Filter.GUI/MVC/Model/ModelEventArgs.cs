using System;
using System.Collections.Generic;
using IMS.SMS.GUI;

namespace IMS.SMS.Filter.GUI {
    public class ModelEventArgs : EventArgs {
        public List<Message> MsgTextList { get; }

        public ModelEventArgs(List<Message> messages) {
            MsgTextList = messages;
        }
    }
}