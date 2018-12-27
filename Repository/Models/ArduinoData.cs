using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Repository.Models
{
    public class ArduinoData
    {
        public int Temperature { get; set; }
        public uint Moisture { get; set; }
        [JsonIgnore]
        public Plant Plant { get; set; }
        public uint PlantId { get; set; }
        [Key]
        public long DataId { get; set; }
        public int Light { get;  set; }
        public int Water { get;  set; }
    }

 
}