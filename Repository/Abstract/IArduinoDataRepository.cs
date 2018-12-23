using Repository.Models;

namespace Repository.Abstract
{
    public interface IArduinoDataRepository
    {
        void SaveData(ArduinoData data);
    }
}
