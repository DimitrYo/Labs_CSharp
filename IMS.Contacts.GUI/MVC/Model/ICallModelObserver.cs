namespace IMS.Contacts.GUI {
    public interface ICallModelObserver {
        void CallListUpdate(ICallModel model, CallModelEventArgs e);
    }
}