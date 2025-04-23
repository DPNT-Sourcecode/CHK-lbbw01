using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    internal class OtherItemFreeOffer : ICrossItemOffer
    {
        public OtherItemFreeOffer(int itemAmount, Char otherSKU) 
        {
            ItemAmount = itemAmount;
            OtherSKU = otherSKU;
        }

        public int ItemAmount { get; }

        public Char OtherSKU { get; }
    }
}
