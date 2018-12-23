using Repository.Models;

namespace ArduinoObserver
{
    public interface IDataHub
    {
        void UpdateData(ArduinoData data);
    }
}