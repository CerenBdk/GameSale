using System;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public interface IPlayerManager:IManager<Player>
    {
        void BuyGame(Player p, Game g, Supplier s);
        void PurchasedGameList(int ID);
    }
}
