using GymApp.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModel
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string NameOfCoach { get; set; }

        public string EventImage { get; set; }

        public int GymID { get; set; }
        public Gym Gym { get; set; }
    }
}
