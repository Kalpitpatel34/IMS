using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models.CustomValidators
{
    class DatePickerValidatorPastToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime passedDate = Convert.ToDateTime(value);

            if (passedDate <= DateTime.Now)
            {
                return null;
            }

            return new ValidationResult($"Date cannot exceed past today", new[] { validationContext.MemberName });
        }
    }
}
