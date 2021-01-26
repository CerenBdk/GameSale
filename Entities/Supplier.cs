using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Entities
{
    public class Supplier:User
    {
        public List<Game> GameList { get; set; }

        public Supplier()
        {
            GameList = new List<Game>();
        }

    }
}
