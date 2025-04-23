using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal class SameItemFreeOffer : ISameItemOffer
    {
        // itemAmount for one free item
        public SameItemFreeOffer(int itemAmount, int price) 
        {
            ItemAmountForOffer = itemAmount;
            Price = price;
        }

        public int ItemAmountForOffer { get; }

        public int Price { get; }

        public int Checkout(int amount)
        {
            return (amount / (ItemAmountForOffer + 1)) * ItemAmountForOffer * Price + (amount % (ItemAmountForOffer + 1)) * Price;
        }
    }
}

