using System;
using GameSale.Entities;
using GameSale.IManagers;
using GameSale.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Managers
{
    public class SupplierManager:ISupplierManager
    {
        public static List<Supplier> supplierList = new List<Supplier>();

        public void Add(Supplier supplier)
        {
            if (supplierList.Any(x => x.FirstName == supplier.FirstName & x.LastName == supplier.LastName))
            {
                Console.WriteLine("{0} {1} is already registered.", supplier.FirstName, supplier.LastName);
            }
            else
            {
                supplier.ID = supplierList.Count + 1;
                supplierList.Add(supplier);
                Console.WriteLine("{0} {1} has been registered.", supplier.FirstName, supplier.LastName);
            } 
        }

        public void Update(Supplier supplier, Supplier supplier1)
        {
            if (supplierList.Any(x => x.ID == supplier.ID))
            {
                supplier.FirstName = supplier1.FirstName;
                supplier.LastName = supplier1.LastName;
                supplier.Email = supplier1.Email;
                supplier.YearOfBirth = supplier1.YearOfBirth;
                Console.WriteLine("{0} {1} has been updated.\n", supplier.FirstName, supplier.LastName);
            }
            else
            {
                Console.WriteLine("{0} {1} is not registered.", supplier.FirstName, supplier.LastName);
            }
        }

        public void Delete(int ID)
        {
            if (ID != 0)
            {
                if (supplierList.Any(x => x.ID == ID))
                {
                    var tempSupplier = supplierList.FirstOrDefault(x => x.ID == ID);
                    supplierList.Remove(tempSupplier);
                    Console.WriteLine("{0} {1} has been deleted.", tempSupplier.FirstName, tempSupplier.LastName);
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
            if (supplierList.Count > 0)
            {
                int count = 1;
                Console.WriteLine("---------- Supplier List ----------");
                foreach (var supplier in supplierList)
                {
                    Console.WriteLine("{0})Identity Number: {1}\n  First Name: {2}\n  Last Name: {3}\n  Birth Date: {4}\n", count, supplier.IdentityNumber, supplier.FirstName, supplier.LastName, supplier.YearOfBirth);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No supplier has been added yet.");
            }
        }

        public Supplier FindByID(int ID)
        {
            Supplier tempSupplier = new Supplier();

            if (supplierList.Any(x => x.ID == ID))
            {
                tempSupplier = supplierList.FirstOrDefault(x => x.ID == ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.", ID);
            }
            return tempSupplier;
        }

        public void AddGameForSupplier(Supplier s, Game g)
        {
            GameManager _gameManager = new GameManager();
            List<Game> gameList = _gameManager.GetList();

            if (gameList.Any(x => x.ID == g.ID))
            {
                s.GameList.Add(g);
                Console.WriteLine("{0} has been added to supplier. ( {1} {2} )", g.Name, s.FirstName, s.LastName);
            }
            else
            {
                if (!supplierList.Any(x => x.ID == s.ID))
                {
                    Console.WriteLine("Supplier was not found.");
                }
                else if (_gameManager.FindByID(g.ID) == null)
                {
                    Console.WriteLine("{0} is not found", g.Name);
                }
            }
        }

        public void OwnedGameList(int ID)
        {
            var supplier = FindByID(ID);
            if (supplier != null)
            {
                if (supplier.GameList != null)
                {
                    int count = 1;
                    foreach (var item in supplier.GameList)
                    {
                        Console.WriteLine("{0})Name: {1}\n  Type: {2}\n  Campaign ID: {3}\n", count, item.Name, item.GameType, item.CampaignID);
                        count++;
                    }
                }
                else
                {
                    Console.WriteLine("This supplier does not have any games.");
                }
            }
            else
            {
                Console.WriteLine("{0} is not registered.", ID);
            }
        }

        public List<Supplier> GetList()
        {
            return supplierList;
        }
    }
}
