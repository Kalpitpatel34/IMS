using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class ComplexModelCollage
    {
        public virtual ICollection<UniqueIdentifiers_Model> UniqueIdentifiers { get; set; }
        public virtual ICollection<NatureOfInjury_Model> NatureOfInjury { get; set; }
        public virtual ICollection<SupplementaryInjuryMechanism_Model> SupplementaryInjuryMechanism { get; set; }
        public virtual ICollection<LocationAssociatedWithInjury_Model> LocationAssociatedWithInjury { get; set; }
        public virtual ICollection<AdditionalInjuryInformation_Model> AdditionalInjuryInformation { get; set; }
    }
}
