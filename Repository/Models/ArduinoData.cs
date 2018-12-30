using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace Repository.Models
{
    public class ArduinoData
    {
        public int Temperature { get; set; }
        public uint Moisture { get; set; }
        [JsonIgnore]
        public Plant Plant { get; set; }
        [Required]
        public uint PlantId { get; set; }
        [Key]
        public long DataId { get; set; }
        public int Light { get;  set; }
        public int Water { get;  set; }
        //public DateTime Time { get; set; }
    }


    public class ArduinoDataSeperate
    {
        public ArduinoDataSeperate(IEnumerable<ArduinoData> datas)
        {
            foreach (var data in datas)
            {
                Temperatures.Add(data.Temperature);
                Moistures.Add(data.Moisture);
                DataIds.Add(data.DataId);
                Lights.Add(data.Light);
                Waters.Add(data.Water);
            }
        }
        public List<int> Temperatures { get; set; } = new List<int>();
        public List<uint> Moistures { get; set; } = new List<uint>();
        public List<long> DataIds { get; set; } = new List<long>();
        public List<int> Lights { get; set; } = new List<int>();
        public List<int> Waters { get; set; } = new List<int>();
    }

 
}