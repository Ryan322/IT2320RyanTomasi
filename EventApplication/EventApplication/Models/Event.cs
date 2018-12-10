using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class Event
    {
        [Required]
        [Display(Name = "Event Title")]
        [Range(1, 50)]
        public virtual string Title { get; set; }

        [Display(Name = "Event Description")]
        [Range(1, 150)]
        public virtual string Description { get; set; }

        [Required]
        [Display(Name = "Event Start Date")]
        public virtual int StartDate { get; set; }

        [Required]
        [Display(Name = "Event Start Time")]
        public virtual int StartTime { get; set; }

        [Required]
        [Display(Name = "Event End Date")]
        public virtual int EndDate { get; set; }

        [Required]
        [Display(Name = "Event End Time")]
        public virtual int EndTime { get; set; }

        [Required]
        [Display(Name = "Event Location")]
        public virtual string Location { get; set; }

    }
}