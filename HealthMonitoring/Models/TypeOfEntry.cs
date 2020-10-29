using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthMonitoring.Models
{
    public class TypeOfEntry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}