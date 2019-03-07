using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Inquba.Databases.Interfaces;

namespace Inquba.Databases.Models
{
    public class Email : BaseModel, IStatus
    {
        [Required]
        public bool Status { get; set; }
        [Required]
        [StringLength(200)]
        public string From { get; set; }
        [Required]
        [StringLength(200)]
        public string To { get; set; }
        [Required]
        [StringLength(200)]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public bool ReadStatus { get; set; }



    }
}