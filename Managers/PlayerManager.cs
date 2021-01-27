using System;
using GameSale.Entities;
using GameSale.IManagers;
using GameSale.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public class PlayerManager:IPlayerManager
    {
        public static List<Player> playerList = new List<Player>();
        CampaignManager _campaignManager;
        SaleManager _saleManager;   
 
        public PlayerManager()
        {
            _saleManager = new SaleManager();
            _campaignManager = new CampaignManager();
        }

        public void Add(Player player)
        {
            if (playerList.Any(x => x.NickName == player.NickName))
            {
                Console.WriteLine("{0} {1} is already registered.", player.FirstName, player.LastName);
            }
            else
            {
                player.ID = playerList.Count + 1;
                playerList.Add(player);
                Console.WriteLine("{0} {1} has been registered.", player.FirstName, player.LastName);
            } 
        }

        public void Update(Player player, Player player1)
        {
            if (playerList.Any(x => x.ID == player.ID))
            {
                player.FirstName = player1.FirstName;
                player.LastName = player1.LastName;
                player.NickName = player1.NickName;
                player.Email = player1.Email;
                player.YearOfBirth = player1.YearOfBirth;
                Console.WriteLine("{0} {1} has been updated.\n", player.FirstName, player.LastName);
            }
            else
            {
                Console.WriteLine("{0} {1} is not registered.", player.FirstName, player.LastName);
            }
        }

        public void Delete(int ID)
        {
            if (ID != 0)
            {
                if (playerList.Any(x => x.ID == ID))
                {
                    var tempPlayer = playerList.FirstOrDefault(x => x.ID == ID);
                    playerList.Remove(tempPlayer);
                    Console.WriteLine("{0} {1} has been deleted.", tempPlayer.FirstName, tempPlayer.LastName);
                }
                else
                {
                    Console.WriteLine("{0} is not found.", ID);
                }
            }
            else
            {
                Console.WriteLine("Undefined ID number");
            }
        }

        public void WriteAll()
        {
            if (playerList.Count > 0)
            {
                int count = 1;
                Console.WriteLine("---------- Player List ----------");
                foreach (var player in playerList)
                {
                    Console.WriteLine("{0})First Name: {1}\n  Last Name: {2}\n  Year Of Birth: {3}\n  Nick Name: {4}\n", count, player.FirstName, player.LastName, player.YearOfBirth, player.NickName);
                    count++;
                }
            }
            else 
            {
                Console.WriteLine("No player has been added yet.");
            }
        }

        public Player FindByID(int ID)
        {
            Player tempPlayer = new Player();

            if (playerList.Any(x => x.ID == ID))
            {
                tempPlayer = playerList.FirstOrDefault(x => x.ID == ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.", ID);
            }
            return tempPlayer;
        }

        public void BuyGame(Player p, Game g, Supplier s)
        {
            Sale sale = new Sale();         
            Random random = new Random();
            sale.ID = random.Next(10000);
            sale.PlayerID = p.ID;
            sale.GameID = g.ID;
            if (s.GameList.Any(x => x.ID == g.ID))
            {
                sale.SupplierID = s.ID;
                if (g.CampaignID == 0)
                {
                    sale.Amount = g.Price;
                    sale.IsPriceDiscounted = false;
                }
                else
                {
                    Campaign campaign = new Campaign();
                    campaign = _campaignManager.FindByID(g.CampaignID);
                    sale.Amount = _saleManager.CalculatedDiscountedPrice(g, campaign);
                    sale.IsPriceDiscounted = true;
                }
                _saleManager.Add(sale);
                p.GameList.Add(g);
                g.PlayerList.Add(p); 
            }
            else 
            {
                Console.WriteLine("{0} is not registered for this supplier.", g.Name);
            }  
        }

        public void PurchasedGameList(int ID)
        {
            var player = FindByID(ID);
            if(player != null)
            {
                if(player.GameList != null)
                {
                    int count = 1;
                    foreach (var item in player.GameList)
                    {
                        Console.WriteLine("{0})Name: {1}\n  Type: {2}\n  Campaign ID: {3}\n", count, item.Name, item.GameType, item.CampaignID);
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("This player has not purchased a game yet.");
                }
            }
            else
            {
                Console.WriteLine("{0} is not registered.", ID);
            }
        }

        public List<Player> GetList()
        {
            return playerList;
        }
    }
}
