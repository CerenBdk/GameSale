using System;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public interface IGameManager:IManager<Game>
    {
        void AddCampagianToGame(Game game, int ID);
        void DeleteCampagianToGame(Game game);
        void UpdateCampaignID(Game game, Campaign campaign);
        void GetPlayerListOfGame(int ID);
    }
}
