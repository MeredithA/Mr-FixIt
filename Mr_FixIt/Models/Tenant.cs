using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class Tenant
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public int BuildingId { get; set; }
        [Display(Name = "Name of Building")]
        public Building Building { get; set; }
        [Display(Name = "Apartment Number")]
        public string ApartmentNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAdrress { get; set; }
    }
}