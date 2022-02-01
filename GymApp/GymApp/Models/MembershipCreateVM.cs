using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class MembershipCreateVM
    {
        public int Gym { get; set; }
        public List<SelectListItem> Gyms { get; set; }


        public int MembershipTypeId { get; set; }
        public string TypeName { get; set; }
        public float Price { get; set; }


        //public int ApplicationUserId { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public float Price { get; set; }
    }
}
