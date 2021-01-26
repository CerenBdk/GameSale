using System;
using GameSale.Managers;
using GameSale.IManagers;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Service
{
    public class VerificationService:IVerificationService<User>
    {
        public static List<User> verifiedUserList =  new List<User>();

        public void Add(User user)
        {
            if (verifiedUserList.Count == 0)
            {
                verifiedUserList.Add(user);
            }
            else
            {
                if (verifiedUserList.Any(x => x.IdentityNumber == user.IdentityNumber))
                {
                    Console.WriteLine("{0} is already registered.\n", user.IdentityNumber);
                }
                else
                {
                    verifiedUserList.Add(user);
                }
            }
        }

        public bool IsVerified(User user)
        {
            bool userVerified = false;
            if (verifiedUserList.Any(
                x => x.IdentityNumber == user.IdentityNumber &
                     x.FirstName == user.FirstName &
                     x.LastName == user.LastName &
                     x.YearOfBirth == user.YearOfBirth)) userVerified = true;
            else userVerified = false;

            return userVerified;    
        }

        public void MessageForAdd()
        {
            Console.WriteLine("User has been successfully verified.\n");
        }

        public List<User> GetVerifiedUserList()
        {
            return verifiedUserList;
        }
    }
}
