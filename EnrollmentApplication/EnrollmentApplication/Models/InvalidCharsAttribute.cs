using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string inv_chars;

        public InvalidCharsAttribute(string invChars)
        {
            inv_chars = invChars;
         }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
            if (value != null)
            {
                // if Notes has invalid characters then error
                if ((string)value = inv_chars)
                {
                    return new ValidationResult("Notes contains unacceptable characters!");
                }
            }


            return ValidationResult.Success;
    }


    }
}