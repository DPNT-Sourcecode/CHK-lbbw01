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

            itemDictionary['B'] -= itemDictionary['E'] / 2;

            var total = (itemDictionary['A'] / 5) * 200 + ((itemDictionary['A'] % 5) / 3) * 130 + ((itemDictionary['A'] % 5) % 3) * 50 +
                itemDictionary['C'] * 20 +
                itemDictionary['D'] * 15 +
                itemDictionary['E'] * 40 +
                (itemDictionary['F'] / 3) * 2 * 10 + (itemDictionary['F'] % 3) * 10 +
                itemDictionary['G'] * 20; //+
                //itemDictionary['H'] * 20;

            if (itemDictionary['B'] > 0)
                total += (itemDictionary['B'] % 2) * 30 + (itemDictionary['B'] / 2) * 45;

            return total;
        }
    }
}
