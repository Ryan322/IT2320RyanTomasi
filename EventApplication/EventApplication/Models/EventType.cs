using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class EventType
    {
        [Required]
        [Display(Name = "Event Type")]
        [Range(1, 50)]
        public virtual string TypeofEvent { get; set; }
    }
}