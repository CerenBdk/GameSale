using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Entities
{
    public class Sale
    {
        private DateTime temp = DateTime.Now;
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public int SupplierID { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt 
        {
            get { return temp; }
            set { temp = value; } 
        }
        public bool IsPriceDiscounted { get; set; }
    }
}
