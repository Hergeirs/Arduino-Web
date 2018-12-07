using System;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace ArduinoObserver
{
    public struct ArduinoData
    {
        public int Temperature { get; set; }
        public uint Moisture { get; set; }
        public User User { get; set; }
        [Key]
        public uint PlantId { get; set; }
        public int Light { get;  set; }
        public int Water { get;  set; }
    }

 
}