using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.SMS.Filter.GUI {

    public delegate void ViewHandler<IView>(IView sender, ViewEventArgs e);

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

    public interface IView {

        event ViewHandler<IView> changed;
        void setController(IController cont);
    }
}
