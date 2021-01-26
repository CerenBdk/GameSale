using System;
using GameSale.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSale.IManagers
{
    public interface ISaleManager:IManager<Sale>
    {
        decimal CalculatedDiscountedPrice(Game g, Campaign c);
    }
}
