using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mr_FixIt.Models
{
    public class TenantCreateViewModel
    {
        public List<Building> Buildings { get; set; }
        public Tenant Tenant { get; set; }
        public SelectList BuildingList { get; set; }
    }
}