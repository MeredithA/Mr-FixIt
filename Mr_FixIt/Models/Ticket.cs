using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mr_FixIt.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nature of Request:")]
        public string NatureOfTicket { get; set; }
        [Display(Name = "Location of the request:")]
        public string LocationOfTheReuqest { get; set; }
        [Display(Name = "Check if you would like updates")]
        public bool ReceiveUpdate { get; set; }
        [Display(Name = "Additional Information:")]
        public string AdditionalInformation { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}