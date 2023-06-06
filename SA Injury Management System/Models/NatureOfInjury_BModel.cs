using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SA_Injury_Management_System.Models
{
    public class NatureOfInjury_BModel
    {
        public string ID { get; set; }
        [Required]
        public string NatureOfActivity { get; set; }
        [Required]
        public string NatureOfInjury { get; set; }
        [Required]
        public string MechanismOfInjury { get; set; }
        [Required]
        public string AreaOfInjury { get; set; }
    }
}
