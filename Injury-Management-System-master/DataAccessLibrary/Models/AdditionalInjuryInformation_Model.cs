using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class AdditionalInjuryInformation_Model
    {
        public string ID { get; set; }
        public string TypeOfInjury { get; set; }
        public string TimeOfInjury { get; set; }
        public string GroundSurface { get; set; }
        public string SeverityOfInjury { get; set; }
        public string DataEnteredBy { get; set; }
    }
}
