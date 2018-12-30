using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Repository.Models
{
    public class Plant
    {
        [Required]
        [Key]
        [Display(Name = "Id á plantuni")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long? PlantId { get; set; }
        [Display(Name = "Navn fyri at tú sjálvur skal síggja mun millum planturnar")]
        public string Name { get; set; }

        [Required]
        [HiddenInput(DisplayValue=false)]
        public DateTime DateAdded { get; set; } = DateTime.Today;
        public ApplicationUser ApplicationUser { get; set; }
        public IList<ArduinoData> Datas { get; set; }
        //public int IdentityUserId { get; set; }
       
    }
}
