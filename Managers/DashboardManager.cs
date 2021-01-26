using GameSale.Entities;
using GameSale.IManagers;
using GameSale.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Managers
{
    public class DashboardManager
    {
        bool flag = true;

        UserManager _userManager = new UserManager();
        PlayerManager _playerManager = new PlayerManager();
        SupplierManager _supplierManager = new SupplierManager();
        GameManager _gameManager = new GameManager();
        CampaignManager _campaignManager = new CampaignManager();
        SaleManager _saleManager = new SaleManager();
        VerificationService _verificationService = new VerificationService();

        public void UserVerification()
        {
            while (flag)
            {
                Console.WriteLine("\n***** LOGIN ******");
                User user = new User();

                Console.WriteLine("\nIdentity Number(TCKN): ");
                user.IdentityNumber = Console.ReadLine();
                Console.WriteLine("First Name: ");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name");
                user.LastName = Console.ReadLine();
                Console.WriteLine("Year of Birth: ");
                user.YearOfBirth = Console.ReadLine();
                bool result = _verificationService.IsVerified(user);
                if (result == true)
                {
                    DashboardOpen();
                    flag = false;
                }
                else
                {
                    Console.WriteLine("This user could not be verified by the system. Please try again.");
                }
            }
        }

        public void DashboardOpen()
        {
            while (flag)
            {
                Console.WriteLine("*************** Welcome To The Market Place ***************");
                Console.WriteLine("                         Main Menu");
                Console.WriteLine("                 1. User Operations");
                Console.WriteLine("                 2. Player Operations");
                Console.WriteLine("                 3. Supplier Operations");
                Console.WriteLine("                 4. Game Operations");
                Console.WriteLine("                 5. Campaign Operations");
                Console.WriteLine("                 6. Purchasing Operation");
                Console.WriteLine("                 7. Exit \n");
                Console.WriteLine("\n** HINT: Please enter the User Operations(1) menu to add new players and new suppliers.\n");
                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        UserOperations();
                        break;
                    case '2':
                        PlayerOperations();
                        break;
                    case '3':
                        SupplierOperations();
                        break;
                    case '4':
                        GameOperations();
                        break;
                    case '5':
                        CampaignOperations();
                        break;
                    case '6':
                        PurchasingOperation();
                        break;
                    case '7':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        #region User Operations
        private void UserOperations()
        {
            while (flag)
            {
                Console.WriteLine("\n                   --- User Operations Menu ---");
                Console.WriteLine("                 1. Add New User");
                Console.WriteLine("                 2. Update User");
                Console.WriteLine("                 3. Delete User");
                Console.WriteLine("                 4. Show list of all users");
                Console.WriteLine("                 5. Add New Player");
                Console.WriteLine("                 6. Add New Supplier");
                Console.WriteLine("                 7. Return to Main Menu");
                Console.WriteLine("                 8. Exit \n");

                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddNewUser();
                        break;
                    case '2':
                        UpdateUser();
                        break;
                    case '3':
                        DeleteUser();
                        break;
                    case '4':
                        UserList();
                        break;
                    case '5':
                        AddNewPlayer();
                        break;
                    case '6':
                        AddNewSupplier();
                        break;
                    case '7':
                        DashboardOpen();
                        break;
                    case '8':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        private void AddNewUser()
        {
            User user = new User();
            Console.WriteLine("Identity Number(TCKN): ");
            user.IdentityNumber = Console.ReadLine();
            Console.WriteLine("First Name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            user.LastName = Console.ReadLine();
            Console.WriteLine("E-mail Address: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Year of Birth: ");
            user.YearOfBirth = Console.ReadLine();

            _userManager.Add(user);
            _verificationService.MessageForAdd();
            Console.WriteLine("{0} {1} has been registered.\n", user.FirstName, user.LastName);
        }

        private void UpdateUser()
        {
            User u = new User();
            _userManager.WriteAll();
            Console.WriteLine("Please select the user to update: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var user = _userManager.FindByID(choice);
            Console.WriteLine("Identity Number(TCKN): ");
            u.IdentityNumber = Console.ReadLine();
            Console.WriteLine("First Name: ");
            u.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            u.LastName = Console.ReadLine();
            Console.WriteLine("E-mail Address: ");
            u.Email = Console.ReadLine();
            Console.WriteLine("Year of Birth: ");
            u.YearOfBirth = Console.ReadLine();
            _userManager.Update(user, u);

        }

        private void DeleteUser()
        {
            _userManager.WriteAll();
            Console.WriteLine("Please select the user to delete: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var userList = _userManager.GetList();
            _userManager.Delete(userList[choice - 1].ID);
        }

        private void UserList()
        {
            _userManager.WriteAll();
        }

        private void AddNewPlayer()
        {
            Player player = new Player();
            Console.WriteLine("First Name: ");
            player.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            player.LastName = Console.ReadLine();
            Console.WriteLine("Nick Name: ");
            player.NickName = Console.ReadLine();
            Console.WriteLine("E-mail Address: ");
            player.Email = Console.ReadLine();
            Console.WriteLine("Year of Birth: ");
            player.YearOfBirth = Console.ReadLine();

            _playerManager.Add(player);
        }

        private void AddNewSupplier()
        {
            Supplier supplier = new Supplier();
            Console.WriteLine("First Name: ");
            supplier.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            supplier.LastName = Console.ReadLine();
            Console.WriteLine("E-mail Address: ");
            supplier.Email = Console.ReadLine();
            Console.WriteLine("Year of Birth: ");
            supplier.YearOfBirth = Console.ReadLine();

            _supplierManager.Add(supplier);
        }

        #endregion

        #region Player Operations
        private void PlayerOperations()
        {
            while (flag)
            {
                Console.WriteLine("\n                   --- Player Operations Menu ---");
                Console.WriteLine("                 1. Update Player");
                Console.WriteLine("                 2. Delete Player");
                Console.WriteLine("                 3. View the list of games purchased for the selected player.");
                Console.WriteLine("                 4. Show list of all players");
                Console.WriteLine("                 5. Return to Main Menu");
                Console.WriteLine("                 6. Exit \n");

                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        UpdatePlayer();
                        break;
                    case '2':
                        DeletePlayer();
                        break;
                    case '3':
                        PurchasedGameList();
                        break;
                    case '4':
                        PlayerList();
                        break;
                    case '5':
                        DashboardOpen();
                        break;
                    case '6':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        private void UpdatePlayer()
        {
            Player p = new Player();
            _playerManager.WriteAll();
            Console.WriteLine("Please select the player to update: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var player = _playerManager.FindByID(choice);
            Console.WriteLine("First Name: ");
            p.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            p.LastName = Console.ReadLine();
            Console.WriteLine("Nick Name: ");
            p.NickName = Console.ReadLine();
            Console.WriteLine("E-mail Address: ");
            p.Email = Console.ReadLine();
            Console.WriteLine("Year of Birth: ");
            p.YearOfBirth = Console.ReadLine();
            _playerManager.Update(player, p);
        }

        private void DeletePlayer()
        {
            _playerManager.WriteAll();
            Console.WriteLine("Please select the player to delete: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var playerList = _playerManager.GetList();
            _playerManager.Delete(playerList[choice - 1].ID);
        }

        private void PurchasedGameList()
        {
            _playerManager.WriteAll();
            Console.WriteLine("Please select the player to view: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var playerList = _playerManager.GetList();
            _playerManager.PurchasedGameList(playerList[choice - 1].ID);
        }

        private void PlayerList()
        {
            _playerManager.WriteAll();
        } 
        #endregion

        #region Supplier Operations
        private void SupplierOperations()
        {
            while (flag)
            {
                Console.WriteLine("\n                   --- Supplier Operations Menu ---");
                Console.WriteLine("                 1. Update Supplier");
                Console.WriteLine("                 2. Delete Supplier");
                Console.WriteLine("                 3. Add new game to supplier");
                Console.WriteLine("                 4. View the list of games added for the selected supplier.");
                Console.WriteLine("                 5. Supplier List");
                Console.WriteLine("                 6. Return to Main Menu");
                Console.WriteLine("                 7. Exit \n");

                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        UpdateSupplier();
                        break;
                    case '2':
                        DeleteSupplier();
                        break;
                    case '3':
                        AddGameToSupplier();
                        break;
                    case '4':
                        OwnedList();
                        break;
                    case '5':
                        SupplierList();
                        break;
                    case '6':
                        DashboardOpen();
                        break;
                    case '7':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        private void UpdateSupplier()
        {
            Supplier s = new Supplier();
            _supplierManager.WriteAll();
            Console.WriteLine("Please select the supplier to update: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var supplier = _supplierManager.FindByID(choice);
            Console.WriteLine("First Name: ");
            s.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            s.LastName = Console.ReadLine();
            Console.WriteLine("E-mail Address: ");
            s.Email = Console.ReadLine();
            Console.WriteLine("Year of Birth: ");
            s.YearOfBirth = Console.ReadLine();
            _supplierManager.Update(supplier, s);
        }

        private void DeleteSupplier()
        {
            _supplierManager.WriteAll();
            Console.WriteLine("Please select the supplier to delete: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var supplierList = _supplierManager.GetList();
            _supplierManager.Delete(supplierList[choice - 1].ID);
        }

        private void AddGameToSupplier()
        {
            _supplierManager.WriteAll();
            Console.WriteLine("Please select the supplier you want to add a new game: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            var supplierList = _supplierManager.GetList();
            var supplier = _supplierManager.FindByID(supplierList[choice1 - 1].ID);
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            var gameList = _gameManager.GetList();
            var game = _gameManager.FindByID(gameList[choice2 - 1].ID);
            _supplierManager.AddGameForSupplier(supplier, game);
        }

        private void OwnedList()
        {
            _supplierManager.WriteAll();
            Console.WriteLine("Please select the supplier you want to add a new game: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            _supplierManager.OwnedGameList(choice1);
        }

        private void SupplierList()
        {
            _supplierManager.WriteAll();
        }

        #endregion

        #region Game Operations
        private void GameOperations()
        {
            while (flag)
            {
                Console.WriteLine("\n                   --- Game Operations Menu ---");
                Console.WriteLine("                 1. Add New Game");
                Console.WriteLine("                 2. Update Game");
                Console.WriteLine("                 3. Delete Game");
                Console.WriteLine("                 4. View players who purchased the selected game.");
                Console.WriteLine("                 5. Game List");
                Console.WriteLine("                 6. Return to Main Menu");
                Console.WriteLine("                 7. Exit \n");

                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddGame();
                        break;
                    case '2':
                        UpdateGame();
                        break;
                    case '3':
                        DeleteGame();
                        break;
                    case '4':
                        PlayerListOfGame();
                        break;
                    case '5':
                        GameList();
                        break;
                    case '6':
                        DashboardOpen();
                        break;
                    case '7':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        private void AddGame()
        {
            Game g = new Game();
            Console.WriteLine("Game Name: ");
            g.Name = Console.ReadLine();
            Console.WriteLine("Game Type: ");
            g.GameType = Console.ReadLine();
            Console.WriteLine("Description: ");
            g.Description = Console.ReadLine();
            Console.WriteLine("Release Year: ");
            g.ReleaseYear = Console.ReadLine();
            Console.WriteLine("Price: ");
            g.Price = Convert.ToDecimal(Console.ReadLine());
            _gameManager.Add(g);
        }

        private void UpdateGame()
        {
            Game g = new Game();
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game to update: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var game = _gameManager.FindByID(choice);
            Console.WriteLine("Game Name: ");
            g.Name = Console.ReadLine();
            Console.WriteLine("Game Type: ");
            g.GameType = Console.ReadLine();
            Console.WriteLine("Description: ");
            g.Description = Console.ReadLine();
            Console.WriteLine("Release Year: ");
            g.ReleaseYear = Console.ReadLine();
            Console.WriteLine("Price: ");
            g.Price = Convert.ToDecimal(Console.ReadLine());
            _gameManager.Update(game, g);
        }

        private void DeleteGame()
        {
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game to delete: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var gameList = _gameManager.GetList();
            _gameManager.Delete(gameList[choice - 1].ID);
        }

        private void PlayerListOfGame()
        {
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game to view: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var game = _gameManager.FindByID(choice);
            _gameManager.GetPlayerListOfGame(game.ID);
        }

        private void GameList()
        {
            _gameManager.WriteAll();
        } 
        #endregion

        #region Campaign Operations
        private void CampaignOperations()
        {
            while (flag)
            {
                Console.WriteLine("\n                   --- Campaign Operations Menu ---");
                Console.WriteLine("                 1. Add Campaign");
                Console.WriteLine("                 2. Update Campaign");
                Console.WriteLine("                 3. Delete Campaign");
                Console.WriteLine("                 4. Add a Campaign to the Game");
                Console.WriteLine("                 5. Update your game's campaign");
                Console.WriteLine("                 6. Delete the game's campaign");
                Console.WriteLine("                 7. Campaign List");
                Console.WriteLine("                 8. Return to Main Menu");
                Console.WriteLine("                 9. Exit \n");

                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddCampaign();
                        break;
                    case '2':
                        UpdateCampaign();
                        break;
                    case '3':
                        DeleteCampaign();
                        break;
                    case '4':
                        AddCampaignToGame();
                        break;
                    case '5':
                        UpdateCampaignForGame();
                        break;
                    case '6':
                        DeleteCampaignFromGame();
                        break;
                    case '7':
                        CampaignList();
                        break;
                    case '8':
                        DashboardOpen();
                        break;
                    case '9':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        private void AddCampaign()
        {
            Campaign campaign = new Campaign();
            Console.WriteLine("Title: ");
            campaign.Title = Console.ReadLine();
            Console.WriteLine("Starting Date: ");
            DateTime userInput;
            if (DateTime.TryParse(Console.ReadLine(), out userInput))
            {
                campaign.StartedAt = userInput;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
            Console.WriteLine("End Date: ");
            DateTime userInput2;
            if (DateTime.TryParse(Console.ReadLine(), out userInput2))
            {
                campaign.CompletedAt = userInput2;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
            Console.WriteLine("Discount Rate: ");
            campaign.DiscountRate = Convert.ToInt32(Console.ReadLine());
            _campaignManager.Add(campaign);
        }

        private void UpdateCampaign()
        {
            Campaign campaign = new Campaign();
            _campaignManager.WriteAll();
            Console.WriteLine("Please select the user to update: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var c = _campaignManager.FindByID(choice);
            Console.WriteLine("Title: ");
            campaign.Title = Console.ReadLine();
            Console.WriteLine("Starting Date: ");
            DateTime userInput;
            if (DateTime.TryParse(Console.ReadLine(), out userInput))
            {
                campaign.StartedAt = userInput;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
            Console.WriteLine("End Date: ");
            DateTime userInput2;
            if (DateTime.TryParse(Console.ReadLine(), out userInput2))
            {
                campaign.CompletedAt = userInput2;
            }
            else
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
            Console.WriteLine("Discount Rate: ");
            campaign.DiscountRate = Convert.ToInt32(Console.ReadLine());
            _campaignManager.Update(c, campaign);
        }

        private void DeleteCampaign()
        {
            _campaignManager.WriteAll();
            Console.WriteLine("Please select the campaign to delete: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var campaignList = _campaignManager.GetList();
            _campaignManager.Delete(campaignList[choice - 1].ID);
        }

        private void AddCampaignToGame()
        {
            _campaignManager.WriteAll();
            Console.WriteLine("Please select a campaign: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            int campaignID = choice1;
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game you want to add a campaign: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            var game = _gameManager.FindByID(choice2);
            _gameManager.AddCampagianToGame(game, campaignID);
        }

        private void UpdateCampaignForGame()
        {
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            var game = _gameManager.FindByID(choice2);
            _campaignManager.WriteAll();
            Console.WriteLine("Please select a campaign: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            var campaign = _campaignManager.FindByID(choice1);
            _gameManager.UpdateCampaignID(game, campaign);
        }

        private void DeleteCampaignFromGame()
        {
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            var game = _gameManager.FindByID(choice2);
            _gameManager.DeleteCampagianToGame(game);
        }

        private void CampaignList()
        {
            _campaignManager.WriteAll();
        } 
        #endregion

        #region Purchase Operations
        private void PurchasingOperation()
        {
            while (flag)
            {
                Console.WriteLine("\n                   --- Purchasing Operations Menu ---");
                Console.WriteLine("                 1. Sell Game");
                Console.WriteLine("                 2. Purchase List");
                Console.WriteLine("                 3. Return to Main Menu");
                Console.WriteLine("                 4. Exit \n");

                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddPurchase();
                        break;
                    case '2':
                        PurchaseList();
                        break;
                    case '3':
                        DashboardOpen();
                        break;
                    case '4':
                        Console.WriteLine("*************** Have a nice day. Good Bye :) ***************");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nYou entered an incorrect value! Please try again.");
                        break;
                }
            }
        }

        private void AddPurchase()
        {
            _gameManager.WriteAll();
            Console.WriteLine("Please select the game to sell: ");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            var game = _gameManager.FindByID(choice2);
            _playerManager.WriteAll();
            Console.WriteLine("Please select the player to purchase: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            var player = _playerManager.FindByID(choice);
            _supplierManager.WriteAll();
            Console.WriteLine("Please select the supplier: ");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            var supplier = _supplierManager.FindByID(choice);
            _playerManager.BuyGame(player, game, supplier);
        }

        private void PurchaseList()
        {
            _saleManager.WriteAll();
        } 
        #endregion
    }
}
