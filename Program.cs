using System;
using GameSale.Entities;
using GameSale.IManagers;
using GameSale.Managers;
using GameSale.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User
            {
                FirstName = "test",
                LastName = "test",
                IdentityNumber = "11111111111",
                Email = "test@test.com",
                YearOfBirth = "1992"
            };

            User u1 = new User
            {
                FirstName = "test1",
                LastName = "test1",
                IdentityNumber = "22222222222",
                Email = "test1@test1.com",
                YearOfBirth = "1993"
            };

            User u2 = new User
            {
                FirstName = "test2",
                LastName = "test2",
                IdentityNumber = "33333333333",
                Email = "test2@test2.com",
                YearOfBirth = "1994"
            };

            UserManager us = new UserManager();
            us.Add(u);
            us.Add(u1);
            us.Add(u2);

            DashboardManager dm = new DashboardManager();
            dm.UserVerification();
           
            Console.ReadLine();
        }
    }
}
