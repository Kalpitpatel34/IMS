using DataAccessLibrary.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SA_Injury_Management_System.Models
{

    //front-end model, for display and validation rather than data access
    public class UniqueIdentifiers_BModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Name has to have at least 1 character")]
        public string Name { get; set; }
        [Required]
        [DatePickerValidatorPastToday]
        public DateTime DOB { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        [DatePickerValidatorPastToday]
        public DateTime Date_of_Injury { get; set; }
        public string UUID { get; set; }
    }
}
