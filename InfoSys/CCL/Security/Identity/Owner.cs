using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Owner
        : Resident
    {
        public Owner(int UID1, string Email1)
            : base(UID1, Email1, nameof(Owner))
        {
        }
    }
}
