using System;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public interface IManager<T> where T:class
    {
        void Add(T entity);
        void Update(T entity, T entity1);
        void Delete(int ID);
        void WriteAll();
        T FindByID(int ID);
        List<T> GetList();
    }
}
