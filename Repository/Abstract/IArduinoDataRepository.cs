using System;
using System.Collections.Generic;
using System.Text;
using Repository.Models;

namespace Repository.Abstract
{
    public interface IArduinoDataRepository
    {
        void SaveData(ArduinoData data);
    }
}
