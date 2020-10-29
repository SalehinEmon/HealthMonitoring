using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthMonitoring.Models
{
    public class EntryFilter
    {
        public int UserId { get; set; }
        public int TypeOfEntry { get; set; }
        public DateTime FromeDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}