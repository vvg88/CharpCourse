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
            return Medicines.Where(medicine => medicine.SymptomsToUse.Any(symp => symp.ContainsIgnoreCase(symptome)));
        }

        public IEnumerable<Medicine> GetAnalogues(Medicine medicine)
        {
            if (medicine == null)
                return Array.Empty<Medicine>();

            var leastEqualSubsCount = Math.Round(medicine.ActiveSubstances.Count / 2.0, MidpointRounding.AwayFromZero);
            return Medicines.Where(someMedicine =>
            {
                if (medicine == someMedicine)
                    return false;
                
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
