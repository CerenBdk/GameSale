using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.Entities
{
    public class Campaign
    {
        private bool temp = true;
        public int ID { get; set; }
        public int? GameID { get; set; }
        public string Title { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public int DiscountRate { get; set; }
    }
}
