using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]
        public virtual int CourseId { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Course Title cannot be blank")]
        [Range(1, 150)]
        public virtual string Title { get; set; }

        [Display(Name = "Description")]
        public virtual string Description { get; set; }

        [Display(Name = "Number of Credits")]
        [Required]
        [Range(1, 4, ErrorMessage = "Number of credits must be between 1 and 4")]
        public virtual int Credits { get; set; }

        public virtual string InstructorName { get; set; }
    }
}