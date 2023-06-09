using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/**
 * Explanation:
 * This implementation is utilizing a nuget package Microsoft.AspNetCore.Components.DataAnnotations.Validation -Version 3.2.0-rc1.20223.4
 * It's done for cases where multiple models need to be implemented in one EditForm. 
 * Check this source for an example of a simple implementation: https://gunnarpeipman.com/blazor-data-annotations-object-graph-validation/
 */
namespace SA_Injury_Management_System.Models
{
    public class ComplexModelCollage
    {
        [Required]
        [ValidateComplexType]
        public UniqueIdentifiers_BModel UidModel { get; set; }

        [Required]
        [ValidateComplexType]
        public NatureOfInjury_BModel NOIModel { get; set; }

        [ValidateComplexType]
        public LocationAssociatedWithInjury_BModel LAWIModel { get; set; }

        [ValidateComplexType]
        public AdditionalInjuryInformation_BModel AIIModel { get; set; }

        public ComplexModelCollage()
        {
            UidModel = new UniqueIdentifiers_BModel();
            NOIModel = new NatureOfInjury_BModel();
            LAWIModel = new LocationAssociatedWithInjury_BModel();
            AIIModel = new AdditionalInjuryInformation_BModel();
        }

    }
}
