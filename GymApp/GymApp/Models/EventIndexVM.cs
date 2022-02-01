using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class EventIndexVM
    {
         public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameOfCoach { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public string Gym { get; set; }
    }
}
