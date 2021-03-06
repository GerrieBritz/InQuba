﻿using InQubaMail.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InQubaMail.Models
{
    public class Location : BaseModel, IStatus
    {
        public bool Status { get; set; }
        [Required]
        public string LocationName { get; set; }
        public virtual Email State { get; set; }
        [Required]
        public int StateId { get; set; }

        public virtual ICollection<Email> Emails { get; set; }
    }
}