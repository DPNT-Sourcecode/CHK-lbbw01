using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public class CheckoutSolution
    {
        public int Checkout(string? skus)
        {
            if (skus == null)
                return -1;

            var itemDictionary = new Dictionary<Char, int>()
            {
                {'A', 0},
                {'B', 0},
                {'C', 0},
                {'D', 0}
            };

            foreach (var sku in skus)
            {
                if (itemDictionary.ContainsKey(sku))
                    itemDictionary[sku]++;
                else
                    return -1;
            }

            var total = (itemDictionary['A'] % 3) * 50 + (itemDictionary['A'] / 3) * 130 +
                (itemDictionary['B'] % 2) * 30 + (itemDictionary['B'] / 2) * 45 +
                itemDictionary['C'] * 20 +
                itemDictionary['D'] * 15;
            
            return total;
        }
    }
}


