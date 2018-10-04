using System.Text;
using System.Threading.Tasks;
using IMS.SMS.GUI;

namespace IMS.SMS.Filter.GUI {
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);

    public interface IModel {

        void OnSmsReceivedMsg(Message msg);
        void Start();
        void Stop();
        void AttachIModelObserver(IModelObserver view);
        void ViewChanged(ViewEventArgs e);
    }
}