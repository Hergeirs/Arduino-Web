using System;
using System.ComponentModel.DataAnnotations;
using Repository;
using Repository.Models;

namespace ArduinoObserver
{
    public struct ArduinoData
    {
        public int Temperature { get; set; }
        public uint Moisture { get; set; }
        public Plant plant { get; set; }
        [Key]
        public uint PlantId { get; set; }
        public int Light { get;  set; }
        public int Water { get;  set; }
    }

 
}