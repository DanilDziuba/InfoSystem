using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Worker : Resident
    {
        public Worker(int UID1, string Email1, string UserType1, int FabricID1)
            : base (UID1, Email1, nameof(Worker))
        {
            FabricID = FabricID1;
        }
        public int FabricID { get; }
    }
}
