using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SA_Injury_Management_System.Models
{
    public class LocationAssociatedWithInjury_BModel
    {
        public string ID { get; set; }
        [Required]
        public string PlaceWhereInjuryOccured { get; set; }
        [Required]
        public string SportOrRecreationalActivity { get; set; }
    }
}
