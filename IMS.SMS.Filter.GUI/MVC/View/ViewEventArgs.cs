using System;

namespace IMS.SMS.Filter.GUI {
    public class ViewEventArgs : EventArgs {
        public string UserToFilter { get; set; }
        public string TextToFilter { get; set; }
        public DateTime MinDateTimeToFilter { get; set; }
        public DateTime MaxDateTimeToFilter { get; set; }
        public string StyleMessage { get; set; }
        public bool FilterByMinDateChecked { get; set; }
        public bool FilterByMaxDateChecked { get; set; }

        public bool OrMode { get; set; }
    }
}
