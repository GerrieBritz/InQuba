using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InQubaMail.Models
{
    public class BaseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(100)]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime UpDatedDate { get; set; }

    }
}