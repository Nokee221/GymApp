using Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class MembershipIndexVM
    {
        public class Row
        {
            public string Gym { get; set; }
            public string ApplicationUser { get; set; }
            public string MembershipTypeName { get; set; }

            public float Price { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

        }

        public List<Row> memberships { get; set; }
        public string q;
    }
}
