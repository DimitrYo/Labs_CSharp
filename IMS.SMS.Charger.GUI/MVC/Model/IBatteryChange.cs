using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.SMS.Charger.GUI {

    public interface IBatteryChange : IDisposable {
        int BatteryChangeValue { get; set; }
        int TimeoutSeconds { get; set; }

        void Start();
        void Stop();
        event Action<int> BatteryChange;
    }
}
