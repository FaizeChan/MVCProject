using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class List
    {
        [Key]
        public int ListID { get; set; }
        public string ListName { get; set; }

        public virtual ICollection<DreamLocation> Locations { get; set; }
    }
}