using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BusinessLogic
{
    public class Pharmacy
    {
        public IReadOnlyList<Medicine> Medicines { get; }

        public Pharmacy(List<Medicine> medicines)
        {
            Medicines = medicines;
        }

        public IEnumerable<Medicine> GetMedicinesByName(string name)
        {
            return from medicine in Medicines
                   where IsStringContains(medicine.Name, name)
                   select medicine;
        }

        public IEnumerable<Medicine> GetMedicinesBySymptomsToUse(string symptome)
        {
            return from medicine in Medicines
                        from symptm in medicine.SymptomsToUse
                        let isSympContained = IsStringContains(symptm, symptome)
                   where isSympContained
                   select medicine;
        }

        private bool IsStringContains(string stringValue, string containedString)
        {
            return stringValue.IndexOf(containedString, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
