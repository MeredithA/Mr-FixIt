using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class TicketXTenant
    {
        [Key]
        public int ID { get; set; }
        public int TicketId { get; set; }
        public Ticket ticket { get; set; }
        public int TenantId { get; set; }
    }
}