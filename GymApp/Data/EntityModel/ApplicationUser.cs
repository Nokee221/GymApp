using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModel
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
    }

}
