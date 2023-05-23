using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public static class Security
    {
        public static bool isUserActive(object userActive)
        {
            User user = (User)userActive;
            return user != null? true: false;
        }
        public static bool isErrorSessionActive(object session)
        {
            if(session != null)
                return true;
            else
                return false;
        }
        public static bool isAdmin(object userActive)
        {
            User user = (User)userActive;
            return user.userType== UserType.Admin?true:false;
        }
    }
}
