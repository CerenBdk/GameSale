using System;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Entities
{
    public class Game: Product
    {
        int temp = 0;
        public int CampaignID 
        {
            get { return temp; }
            set { temp = value; }
        }
        public string GameType { get; set; }
        public string ReleaseYear { get; set; }
        public string Description { get; set; }
        public Supplier Supplier { get; set; }

        public List<Player> PlayerList { get; set; }

        public Game()
        {
            PlayerList = new List<Player>();
            Supplier = new Supplier();
        }
    }
}
