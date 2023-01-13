using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Admin
        : Worker
    {
        public Admin(int UID1, string Email1, int DistrictID1)
            : base(UID1, Email1, nameof(Admin), DistrictID1)
        {
        }
    }
}
