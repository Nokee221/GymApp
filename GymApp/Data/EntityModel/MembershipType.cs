using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModel
{
    public class MembershipType
    {
        public int MembershipTypeId { get; set; }

        public String TypeName { get; set; }
        public float Price { get; set; }
    }
}
