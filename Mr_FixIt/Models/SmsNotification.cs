using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class SmsNotification
    {
        [Key]
        public int ID { get; set; }
        public bool Updated { get; set; }
    }
}