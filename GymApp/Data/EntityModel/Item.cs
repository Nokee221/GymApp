using GymApp.EntityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModel
{
    public class Item
    {

        public Item()
        {
            this.Gyms = new HashSet<Gym>();
        }

        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public string ItemImage { get; set; }

        public virtual ICollection<Gym> Gyms { get; set; }
    }
}
