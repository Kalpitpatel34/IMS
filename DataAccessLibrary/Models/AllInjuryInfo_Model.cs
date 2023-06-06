using System;

namespace DataAccessLibrary.Models
{
    public class AllInjuryInfo_Model
    {
        public int ID { get; set; }
        public string NatureOfActivity { get; set; }
        public string NatureOfInjury { get; set; }
        public string MechanismOfInjury { get; set; }
        public string AreaOfInjury { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public DateTime Date_of_Injury { get; set; }
        public string UUID { get; set; }
        public string TypeOfInjury { get; set; }
        public string TimeOfInjury { get; set; }
        public string GroundSurface { get; set; }
        public string SeverityOfInjury { get; set; }
        public string DataEnteredBy { get; set; }
        public string PlaceWhereInjuryOccured { get; set; }
        public string SportOrRecreationalActivity { get; set; }
    }
}
