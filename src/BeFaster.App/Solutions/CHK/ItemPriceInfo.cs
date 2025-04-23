using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal class ItemPriceInfo
    {
        public ItemPriceInfo(Char sku, int price, IOffer? offer = null) 
        {
            SKU = sku;
            Price = price;
            Offer = offer;
        }

        public Char SKU { get; }

        public int Price { get; }

        public IOffer? Offer { get; } = null;
    }
}

