using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
    {
        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "Student ID cannot be blank")]
        public virtual int StudentId { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name cannot be blank")]
        [Range(1, 50)]
        public virtual string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name cannot be blank")]
        [Range(1, 50)]
        public virtual string FirstName { get; set; }

        // [InvalidChars(20)] - Custom Data Annotation
        public virtual string Notes { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }


        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // validate 1 Addess2 cant be Address1
            if (Address2.Equals(Address1))
            {
                yield return (new ValidationResult("Address2 cannot be the same as Address1.", new[] { "Address" }));
            }

            // validate 2 State has to be 2 digits
            if (State >= 10 && State <=99)
            {
                yield return (new ValidationResult("Enter a 2 digit State code.", new[] { "State" }));
            }

            // validate 3 Zipcode has to be 5 digits
            if (Zipcode >= 10000 && Zipcode <= 99999)
            {
                yield return (new ValidationResult("Enter a 5 digit zipcode.", new[] { "Zipcode" }));
            }
        }*/
    }
}