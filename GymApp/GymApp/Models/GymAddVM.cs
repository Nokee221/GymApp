using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class GymAddVM
    {
        public int ID { get; set; }
        

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public IFormFile GymImage { get; set; }
    }
}
