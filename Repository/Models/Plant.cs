﻿using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Plant
    {
        public uint PlantId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IList<ArduinoData> Datas { get; set; }
       
    }
}