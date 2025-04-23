using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public class CheckoutSolution
    {
        public int Checkout(string? skus)
        {
            if (skus == null)
                return -1;

            var itemDictionary = new Dictionary<Char, int>();
            
            for (var c = 'A'; c <= 'Z'; c++)
                itemDictionary[c] = 0;

            foreach (var sku in skus)
            {
                if (itemDictionary.TryGetValue(sku, out int value))
                    itemDictionary[sku] = ++value;
                else
                    return -1;
            }

            //itemDictionary['B'] -= itemDictionary['E'] / 2;

            //var total = (itemDictionary['A'] / 5) * 200 + ((itemDictionary['A'] % 5) / 3) * 130 + ((itemDictionary['A'] % 5) % 3) * 50 +
            //    itemDictionary['C'] * 20 +
            //    itemDictionary['D'] * 15 +
            //    itemDictionary['E'] * 40 +
            //    (itemDictionary['F'] / 3) * 2 * 10 + (itemDictionary['F'] % 3) * 10 +
            //    itemDictionary['G'] * 20; //+
            //    //itemDictionary['H'] * 20;

            //if (itemDictionary['B'] > 0)
            //    total += (itemDictionary['B'] % 2) * 30 + (itemDictionary['B'] / 2) * 45;

            //return total;

            var groupOffer = new GroupOffer(3, 45);
            var itemPrices = new Dictionary<Char, ItemPriceInfo>()
            {
                {'A', new ItemPriceInfo('A', 50, new MultibuyOffer(3, 130, 5, 200, 50)) },
                {'B', new ItemPriceInfo('B', 30, new MultibuyOffer(2, 45, 30)) },
                {'C', new ItemPriceInfo('C', 20)},
                {'D', new ItemPriceInfo('D', 15)},
                {'E', new ItemPriceInfo('E', 40, new OtherItemFreeOffer(2, 'B')) },
                {'F', new ItemPriceInfo('F', 10, new SameItemFreeOffer(2, 10)) },
                {'G', new ItemPriceInfo('G', 20 )},
                {'H', new ItemPriceInfo('H', 10, new MultibuyOffer(5, 45, 10, 80, 10)) },
                {'I', new ItemPriceInfo('I', 35 )},
                {'J', new ItemPriceInfo('J', 60 )},
                {'K', new ItemPriceInfo('K', 70, new MultibuyOffer(2, 120, 70)) },
                {'L', new ItemPriceInfo('L', 90) },
                {'M', new ItemPriceInfo('M', 15) },
                {'N', new ItemPriceInfo('N', 40, new OtherItemFreeOffer(3, 'M')) },
                {'O', new ItemPriceInfo('O', 10) },
                {'P', new ItemPriceInfo('P', 50, new MultibuyOffer(5, 200, 50)) },
                {'Q', new ItemPriceInfo('Q', 30, new MultibuyOffer(3, 80, 30)) },
                {'R', new ItemPriceInfo('R', 50, new OtherItemFreeOffer(3, 'Q')) },
                {'S', new ItemPriceInfo('S', 20, groupOffer) },
                {'T', new ItemPriceInfo('T', 20, groupOffer) },
                {'U', new ItemPriceInfo('U', 40, new SameItemFreeOffer(3, 40)) },
                {'V', new ItemPriceInfo('V', 50, new MultibuyOffer(2, 90, 3, 130, 50)) },
                {'W', new ItemPriceInfo('W', 20) },
                {'X', new ItemPriceInfo('X', 17, groupOffer) },
                {'Y', new ItemPriceInfo('Y', 20, groupOffer) },
                {'Z', new ItemPriceInfo('Z', 21, groupOffer) }
            };
            
            // process offers involving free items of a different SKU
            foreach (var itemPrice in itemPrices.Values.Where(x => x.Offer is OtherItemFreeOffer))
            {
                if (itemPrice.Offer is OtherItemFreeOffer offer)
                {
                    itemDictionary[offer.OtherSKU] -= itemDictionary[itemPrice.SKU] / offer.ItemAmount;
                    if (itemDictionary[itemPrice.SKU] < 0)
                        itemDictionary[itemPrice.SKU] = 0;
                }
            }

            // process items eligible for group offer
            var groupItemPrices = new List<int>();
            foreach (var itemPrice in itemPrices.Values.Where(x => x.Offer is GroupOffer))
            {
                if (itemPrice.Offer is GroupOffer offer)
                {
                    for (int i = 0; i < itemDictionary[itemPrice.SKU]; i++)
                        groupItemPrices.Add(itemPrice.Price);
                }
            }
            var total = (groupItemPrices.Count / groupOffer.ItemAmount) * groupOffer.BulkBuyPrice;
            groupItemPrices.Sort();
            total += groupItemPrices.Take(groupItemPrices.Count % groupOffer.ItemAmount).Sum();
                

            // process all items in the basket
            for (var c = 'A'; c <= 'Z'; c++)
            {
                var amount = itemDictionary[c];
                if (amount > 0)
                {
                    if (itemPrices[c].Offer is null || itemPrices[c].Offer is not ISameItemOffer)
                        total += amount * itemPrices[c].Price;
                    else
                        total += (itemPrices[c].Offer as ISameItemOffer).Checkout(amount);
                }        
            }

            return total;
        }
    }
}

