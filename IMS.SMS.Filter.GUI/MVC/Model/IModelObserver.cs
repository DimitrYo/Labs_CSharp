namespace IMS.SMS.Filter.GUI {
    public interface IModelObserver {
        void MessageBoxUpdate(IModel model, ModelEventArgs e);
    }
}