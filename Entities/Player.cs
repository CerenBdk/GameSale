using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Entities
{
    public class Player: User
    {
        public string NickName { get; set; }
        public List<Game> GameList { get; set; }

        public Player()
        {
            GameList = new List<Game>();
        }
    }
}
