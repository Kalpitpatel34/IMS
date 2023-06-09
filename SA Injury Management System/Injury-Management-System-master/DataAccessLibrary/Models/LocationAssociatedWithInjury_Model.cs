using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class LocationAssociatedWithInjury_Model
    {
        public string ID { get; set; }
        public string PlaceWhereInjuryOccured { get; set; }
        public string SportOrRecreationalActivity{ get; set; }
    }
}
