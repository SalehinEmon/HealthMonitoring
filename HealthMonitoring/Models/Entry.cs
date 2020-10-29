using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthMonitoring.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public float Value { get; set; }
        [Required]
        public int TypeOfEntry { get; set; }
        [Required]
        public DateTime DateOfEntry { get; set; }

    }
}