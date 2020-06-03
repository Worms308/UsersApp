using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Session
{
    class UserSession
    {
        public String currentUser { get; set; }
        private static UserSession instance;
        private UserSession()
        {

        }

        public static UserSession getInstance()
        {
            return instance ?? (instance = new UserSession());
        }


    }
}
