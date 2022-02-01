using GymApp.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModel
{
    public class Membership
    {
        public int MembershipId { get; set; }

        public int GymID { get; set; }
        public Gym Gym { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
