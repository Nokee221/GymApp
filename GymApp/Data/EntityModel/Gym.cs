using Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.EntityModel
{
    public class Gym
    {

        public Gym()
        {
            this.Items = new HashSet<Item>();
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string GymImage { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
