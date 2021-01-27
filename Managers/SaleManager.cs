using System;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public class SaleManager:ISaleManager
    {

        public static List<Sale> saleList = new List<Sale>();

        public void Add(Sale sale)
        {
            saleList.Add(sale);
            Console.WriteLine("The game with ID number {0} was purchased by player with ID number {1} for {2} $ from supplier with ID number {3}.", sale.GameID, sale.PlayerID, sale.Amount, sale.SupplierID);
        }

        public void Update(Sale sale, Sale sale1)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public void WriteAll()
        {
            if (saleList.Count > 0)
            {
                int count = 1;
                Console.WriteLine("---------- Sale List ----------");
                foreach (var item in saleList)
                {
                    Console.WriteLine("{0})ID: {1}\n  Player ID: {2}\n  Game ID: {3}\n  Supplier ID: {4}\n  Date: {5}\n  Amount: {6}\n  ", count, item.ID, item.PlayerID, item.GameID, item.SupplierID, item.CreatedAt, item.Amount);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No sale has been added yet.");
            }
        }

        public Sale FindByID(int ID)
        {
            Sale tempSale = new Sale();

            if (saleList.Any(x => x.ID == ID))
            {
                tempSale = saleList.FirstOrDefault(x => x.ID == ID);
            }
            else
            {
                Console.WriteLine("{0} is not found.", ID);
                tempSale = null;
            }
            return tempSale;
        }

        public decimal CalculatedDiscountedPrice(Game g, Campaign c)
        {
            decimal totalAmount = 0;
            if (g.CampaignID == c.ID && c.GameID == g.ID)
            {
                totalAmount = g.Price - (g.Price * c.DiscountRate / 100);
            }
            else
            {
                Console.WriteLine("Game ID and campaign ID don't match.");
            }
            return totalAmount;
        }

        public List<Sale> GetList()
        {
            return saleList;
        }
    }
}
