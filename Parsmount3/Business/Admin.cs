using Parsmount3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsmount3.Business
{
    public class Admin
    {
        public int admin_Id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string gender { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public String LogIn(Admin ad)
        {
            return AdminDA.LogIn(ad);

        }
    }
}