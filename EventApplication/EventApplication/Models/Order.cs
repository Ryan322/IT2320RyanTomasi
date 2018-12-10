using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class Order
    {
        [Required]
        [Display(Name = "Max Tickets")]
        [Range(1, 999)]
        public virtual int MaxTickets { get; set; }

        [Required]
        [Display(Name = "Available Tickets")]
        [Range(1, 999)]
        public virtual string Title { get; set; }
    }
}