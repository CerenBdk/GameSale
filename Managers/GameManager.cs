using System;
using GameSale.Entities;
using GameSale.IManagers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public class GameManager:IGameManager
    {

        public static List<Game> gameList = new List<Game>();

        public void Add(Game game)
        {
            if (gameList.Any(x => x.Name== game.Name))
            {
                Console.WriteLine("{0} has already been added.", game.Name);
            }
            else
            {
                game.ID = gameList.Count + 1;
                gameList.Add(game);
                Console.WriteLine("{0} has been added.", game.Name);
            } 
        }

        public void Update(Game game, Game game1)
        {
            if (gameList.Any(x => x.ID == game.ID))
            {
                game.Name = game1.Name;
                game.GameType = game1.GameType;
                game.Description = game1.Description;
                game.ReleaseYear = game1.ReleaseYear;
                game.Price = game1.Price;
                Console.WriteLine("{0} has been updated.\n", game.Name);
            }
            else
            {
                Console.WriteLine("{0} is not found.", game.Name);
            }
        }

        public void Delete(int ID)
        {
            if (ID != 0)
            {
                if (gameList.Any(x => x.ID == ID))
                {
                    var tempGame = gameList.FirstOrDefault(x => x.ID == ID);
                    gameList.Remove(tempGame);
                    Console.WriteLine("{0} has been deleted.", tempGame.Name);
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
            if (gameList.Count > 0)
            {
                int count = 1;
                Console.WriteLine("---------- Game List ----------");
                foreach (var item in gameList)
                {
                    Console.WriteLine("{0})ID: {1}\n  Name: {2}\n  Type: {3}\n  Release Year: {4}\n  Description: {5}\n  Campaign ID: {6}\n", count, item.ID, item.Name, item.GameType, item.ReleaseYear, item.Description, item.CampaignID);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No game has been added yet.");
            }
        }

        public Game FindByID(int ID)
        {
            Game tempGame = new Game();

            if (gameList.Any(x=>x.ID == ID))
            {
                tempGame= gameList.FirstOrDefault(x => x.ID == ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.", ID);
                tempGame = null;
            }
            return tempGame;
        }

        public void AddCampagianToGame(Game game, int ID)
        {
            CampaignManager _campaignService = new CampaignManager();
            if (_campaignService.FindByID(ID) != null)
            {
                Campaign campaign = _campaignService.FindByID(ID);
                if(gameList.Any(x => x.ID == game.ID))
                {
                    if (game.CampaignID == null || game.CampaignID == 0)
                    {
                        game.CampaignID = campaign.ID;
                        Console.WriteLine("{0} campaign has been added to {1}.", campaign.Title, game.Name);
                    }
                    else
                    {
                        Console.WriteLine("This game already has a campaign: {0}", campaign.Title);
                    }
                }    
            }
            else
            {
                Console.WriteLine("{0} is not found.", ID);
            }
        }

        public void DeleteCampagianToGame(Game game)
        {
            if (gameList.Any(x => x.ID == game.ID))
            {
                int tempID = game.CampaignID;
                game.CampaignID = 0;
                Console.WriteLine("{0} campaign has been deleted to {1}.", tempID, game.Name); 
            }
            else
            {
                Console.WriteLine("{0} is not found.", game.Name);
            }
        }

        public void GetPlayerListOfGame(int ID)
        {
            var game = FindByID(ID);
            if (game != null)
            {
                if (game.PlayerList.Count > 0)
                {
                    int count = 1;
                    foreach (var item in game.PlayerList)
                    {
                        Console.WriteLine("{0})ID: {1}\n  First Name: {2}\n  Last Name: {3}\n  Nick Name: {4}\n", count, item.ID, item.FirstName, item.LastName, item.NickName);
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("This game has not yet been purchased by a player");
                }
            }
            else
            {
                Console.WriteLine("{0} is not registered.", ID);
            }
        }

        public List<Game> GetList()
        {
            return gameList;
        }

        public void UpdateCampaignID(Game game, Campaign campaign)
        {
            if (gameList.Any(x => x.ID == game.ID))
            {
                game.CampaignID = campaign.ID;
                Console.WriteLine("Number {0} has been updated.", game.ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.", game.Name);
            }
        }

    }
}
