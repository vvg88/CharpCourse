using System;
using System.Collections.Generic;
using System.Linq;

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
                   where medicine.Name.ContainsIgnoreCase(name)
                   select medicine;
        }

        public IEnumerable<Medicine> GetMedicinesBySymptomsToUse(string symptome)
        {
            return Medicines.Where(medicine =>
            {
                bool isSympContained = false;
                foreach (var symp in medicine.SymptomsToUse)
                {
                    if (isSympContained = symp.ContainsIgnoreCase(symptome))
                    {
                        break;
                    }
                }
                return isSympContained;
            });
        }

        public IEnumerable<Medicine> GetAnalogues(Medicine medicine)
        {
            return Medicines.Where(someMedicine =>
            {
                if (medicine == someMedicine)
                    return false;

                var leastEqualSubsCount = Math.Round(medicine.ActiveSubstances.Count / 2.0, MidpointRounding.AwayFromZero);
                var equalSubsCount = medicine.ActiveSubstances.Count(actSubstance =>
                {
                    foreach(var someActSubstance in someMedicine.ActiveSubstances)
                    {
                        if (actSubstance == someActSubstance)
                            return true;
                    }
                    return false;
                });
                return equalSubsCount >= leastEqualSubsCount;
            });
        }
    }
}
