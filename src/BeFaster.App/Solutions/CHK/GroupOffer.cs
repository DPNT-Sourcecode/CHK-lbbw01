using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal class GroupOffer : IOffer
    {
        public GroupOffer(int amount, int bulkBuyPrice) 
        {
            ItemAmount = amount;
            BulkBuyPrice = bulkBuyPrice;
        }

        public int ItemAmount { get; }

        public int BulkBuyPrice { get; }
    }
}
