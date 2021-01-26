using System;
using GameSale.Entities;
using GameSale.IManagers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public interface ISupplierManager:IManager<Supplier>
    {
        void AddGameForSupplier(Supplier supplier, Game game);
        void OwnedGameList(int ID);
    }
}
