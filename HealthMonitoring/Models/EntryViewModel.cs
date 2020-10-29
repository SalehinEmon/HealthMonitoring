using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Models
{
    public class EntryViewModel
    {
        public Entry Entry { get; set; }
        public List<SelectListItem> AllItems { get; set; }
    }
}