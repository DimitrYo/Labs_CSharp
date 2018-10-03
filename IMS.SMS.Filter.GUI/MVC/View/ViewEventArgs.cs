using System;

namespace IMS.SMS.Filter.GUI {
    public class ViewEventArgs : EventArgs {
        public string UserToFilter { get; set; }
        public string TextToFilter { get; set; }
        public DateTime MinDateTimeToFilter { get; set; }
        public DateTime MaxDateTimeToFilter { get; set; }
        public string StyleMessage { get; set; }
        public bool FilterByMinDateChecked { get; set; }
        public bool FilterByMaxDateChecked { get; internal set; }

        public ViewEventArgs(string userToFilter, string textToFilter,
                            DateTime minDateTimeToFilter, DateTime maxDateTimeToFilter,
                            string styleMessage,
                            bool filterByMinDate, bool filterByMaxDate) {
            UserToFilter = userToFilter;
            TextToFilter = textToFilter;
            MinDateTimeToFilter = minDateTimeToFilter;
            MaxDateTimeToFilter = maxDateTimeToFilter;
            StyleMessage = styleMessage;
            FilterByMinDateChecked = filterByMinDate;
            FilterByMaxDateChecked = filterByMaxDate;
        }
    }
}
