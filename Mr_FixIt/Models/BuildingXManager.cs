using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class BuildingXManager
    {
        [Key]
        public int ID { get; set; }
        public int BuildId { get; set; }
        public Building building { get; set; }
        public int ManagerId { get; set; }
        //public Manager Manager { get; set; }
    }
}