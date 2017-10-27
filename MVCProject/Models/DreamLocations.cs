using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class DreamLocation
    {
        [Key]
        public int DreamLocationID { get; set; }
        public string ItemName { get; set; }
        public DateTime DateFounded { get; set; }
        public string Details { get; set; }

        [ForeignKey("List")]
        public int ListID { get; set; }
        public virtual List List { get; set; }
    }
}