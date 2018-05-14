using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public Employee Employee { get; set; }
    }
}