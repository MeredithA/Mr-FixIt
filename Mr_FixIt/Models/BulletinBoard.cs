
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class BulletinBoard
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Subject:")]
        public string Subject { get; set; }
        [Display(Name = "Building:")]
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        [Display(Name = "Message:")]
        public string Message { get; set; }
        [Display(Name = "Last Updated:")]
        public string DateEdited { get; set; }
        [Display(Name = "Date Posted:")]
        public string DatePosted { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        [Display(Name = "Visable To Tenants?")]
        public bool VisableToTenants { get; set; }
    }
}