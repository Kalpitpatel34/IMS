using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SA_Injury_Management_System.Models
{
    public class AdditionalInjuryInformation_BModel
    {
        public string ID { get; set; }
        public string TypeOfInjury { get; set; }
        public string TimeOfInjury { get; set; }
        public string GroundSurface { get; set; }
        public string SeverityOfInjury { get; set; }
        public string DataEnteredBy { get; set; }
    }
}
