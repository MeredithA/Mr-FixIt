using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mr_FixIt.Models
{
    public class BulletinListViewModel
    {
        public List<BulletinBoard> AllBulletins { get; set; }
        public List<BulletinBoard> OwnedBulletins { get; set; }
    }
}