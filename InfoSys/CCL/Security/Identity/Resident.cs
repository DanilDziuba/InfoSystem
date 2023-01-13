using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Resident
    {
        public Resident(int UID1, string Email1, string UserType1)
        {
            UID = UID1;
            Email = Email1;
            UserType = UserType1;
        }
        public int UID { get; }
        public string Email { get; }
        protected string UserType { get; }
    }
}
