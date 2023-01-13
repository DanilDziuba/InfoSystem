using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security
{
    public static class SecurityContext
    {
        static Resident _user = null;
        static bool _isWorker = false;

        public static Resident GetUser()
        {
            return _user;
        }

        public static bool GetIsWorker()
        {
            return _isWorker;
        }

        public static void SetUser(Resident user, bool isWorker)
        {
            _user = user;
            _isWorker = isWorker;
        }


    }
}
