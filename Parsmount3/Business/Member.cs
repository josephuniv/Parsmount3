using Parsmount3.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parsmount3.Business
{
    public class Member
    {
        public int member_Id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public DateTime birth_date { get; set; }

        public string gender { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public int address_id { get; set; }

        public string password { get; set; }

        public String LogIn(Member mem)
        {
            return MemberDA.LogIn(mem);
        }
    }
}