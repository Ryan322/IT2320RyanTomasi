using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int EnrollmentId { get; set; }

        public virtual int StudentId { get; set; }

        public virtual int CourseId { get; set; }

        [Display(Name = "Grade")]
        [Required]
        [RegularExpression("A - F", ErrorMessage = "Grade must be letter value")]
        public virtual string Grade { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }

        public virtual bool IsActive { get; set; }

        [Display(Name = "Assigned Campus")]
        [Required(ErrorMessage = "Assigned Campus cannot be blank")]
        public virtual string AssignedCampus { get; set; }

        [Display(Name = "Enrolled in Semester")]
        [Required(ErrorMessage = "Semester cannot be blank")]
        public virtual string EnrollmentSemester { get; set; }

        [Display(Name = "Enrollment Year")]
        [Required]
        [Range (2018, 9999, ErrorMessage = "Year cannot be less than 2018")]
        public virtual int EnrollmentYear { get; set; }
    }
}