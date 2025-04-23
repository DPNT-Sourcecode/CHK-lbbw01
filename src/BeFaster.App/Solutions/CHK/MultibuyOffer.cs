using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal class MultibuyOffer : ISameItemOffer
    {
        public MultibuyOffer(int itemAmount, int bulkBuyPrice, int price)
        {
            Offers.Add((itemAmount, bulkBuyPrice));
            Price = price;
        }

        public MultibuyOffer(int itemAmount1, int bulkBuyPrice1, int itemAmount2, int bulkBuyPrice2, int price)
        {
            Debug.Assert(bulkBuyPrice1/itemAmount1 >  bulkBuyPrice2/itemAmount2);
            Offers.Add((itemAmount1, bulkBuyPrice1));
            Offers.Add((itemAmount2, bulkBuyPrice2));
            Price = price;
        }

        public List<(int itemAmount, int bulkBuyPrice)> Offers { get; } = [];

        public int Price { get; }

        public int Checkout(int amount)
        {
            var total = 0;
            var currentAmount = amount;
            foreach ((int itemAmountForOfferm, int bulkBuyPrice) in Offers)
            {
                total += (currentAmount / itemAmountForOfferm) * bulkBuyPrice;
                currentAmount = currentAmount % itemAmountForOfferm;
            }
            return total + currentAmount * Price;
        }
    }
}
