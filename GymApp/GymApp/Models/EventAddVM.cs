using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class EventAddVM
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string NameOfCoach { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public IFormFile EventImage { get; set; }
        public int GymID { get; set; }
    }
}
