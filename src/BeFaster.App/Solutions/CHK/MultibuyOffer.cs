using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal class MultibuyOffer : IOffer
    {
        public MultibuyOffer(int itemAmount, int bulkBuyPrice)
        {
            Offers.Add((itemAmount, bulkBuyPrice));
        }

        public MultibuyOffer(int itemAmount1, int bulkBuyPrice1, int itemAmount2, int bulkBuyPrice2)
        {
            Debug.Assert(bulkBuyPrice1/itemAmount1 >  bulkBuyPrice2/itemAmount2);
            Offers.Add((itemAmount1, bulkBuyPrice1));
            Offers.Add((itemAmount2, bulkBuyPrice2));
        }

        public List<(int itemAmount, int bulkBuyPrice)> Offers { get; } = [];
    }
}

