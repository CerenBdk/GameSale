using System;
using GameSale.Entities;
using GameSale.IManagers;
using GameSale.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public class UserManager:IUserManager
    {
        public static List<User> userList = new List<User>();
        VerificationService _verificationService;

        public UserManager()
        {
            _verificationService = new VerificationService();
        }

        public void Add(User user)
        {
            if(_verificationService.GetVerifiedUserList().Any(x => x.IdentityNumber == user.IdentityNumber))
            {
                Console.WriteLine("{0} is already registered.\n", user.IdentityNumber);
            }
            else
            {
                user.ID = userList.Count + 1;
                userList.Add(user);
                _verificationService.Add(user);  
            }  
        }

        public void Update(User user, User user1)
        {
            if (userList.Any(x => x.ID == user.ID))
            {
                user.FirstName = user1.FirstName;
                user.LastName = user1.LastName;
                user.Email = user1.Email;
                user.YearOfBirth = user1.YearOfBirth;
                Console.WriteLine("{0} {1} has been updated.\n", user.FirstName, user.LastName);
            }
            else
            {
                Console.WriteLine("{0} {1} is not registered.\n", user.FirstName, user.LastName);
            }
        }

        public void Delete(int ID)
        {
            if (ID != 0)
            {
                if (userList.Any(x => x.ID == ID))
                {
                    var tempUser= userList.FirstOrDefault(x => x.ID == ID);
                    userList.Remove(tempUser);
                    Console.WriteLine("{0} {1} has been deleted.\n", tempUser.FirstName, tempUser.LastName);
                }
                else
                {
                    Console.WriteLine("{0} is not found.\n", ID);
                }
            }
            else
            {
                Console.WriteLine("Undefined ID number.\n");
            }
        }

        public User FindByID(int ID)
        {
            User tempUser = new User();

            if (userList.Any(x => x.ID == ID))
            {
                tempUser = userList.FirstOrDefault(x => x.ID == ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.\n", ID);
            }

            return tempUser;
        }

        public void WriteAll()
        {
            if (userList.Count > 0)
            {
                int count = 1;
                Console.WriteLine("---------- User List ----------");
                foreach (var user in userList)
                {
                    Console.WriteLine("     {0})Identity Number: {1}\n       First Name: {2}\n       Last Name: {3}\n       Birth Date: {4}\n", count, user.IdentityNumber, user.FirstName, user.LastName, user.YearOfBirth);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No user has been added yet.\n");
            }
        }

        public List<User> GetList()
        {
            return userList;
        }
    }
}
