using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentClass
{
    public class Security
    {
        public static bool Login(string username, string password)
        {
            using (StudentClassEntities db=new StudentClassEntities())
            {
                return db.users.Any(user=>user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password==password);
            }
        }
    }
}