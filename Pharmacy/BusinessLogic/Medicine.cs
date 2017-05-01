using System;
using System.Collections.Generic;

namespace Pharmacy.BusinessLogic
{
    public class Medicine
    {
        public string Name { get; }
        public decimal Price { get; private set; }
        public IReadOnlyList<string> ActiveSubstances { get; }
        public IReadOnlyList<string> SymptomsToUse { get; }

        public Medicine(string name, decimal price, List<string> activeSubstances, List<string> symptomsToUse)
        {
            Name = name;
            Price = price;
            ActiveSubstances = activeSubstances;
            SymptomsToUse = symptomsToUse;
        }

        public void SetNewPrice(decimal newPrice)
        {
            Price = newPrice;
        }
    }
}
