using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory.Models
{
    public class UserBL
    {
        FactoryDBEntitie db = new FactoryDBEntitie();

        public List<User> GetUsers()
        {
             List<User> users = new List<User>();

            foreach (User user in db.Users)
            {
                users.Add(user);
            }
            return users;   
        }




    }
}