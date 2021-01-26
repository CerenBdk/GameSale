using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Service
{
    public interface IVerificationService<T> where T:class
    {
        void Add(T entitiy);
        bool IsVerified(T entity);
        void MessageForAdd();
        List<T> GetVerifiedUserList();
    }
}
