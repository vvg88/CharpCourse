using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Pharmacy.BusinessLogic
{
    public class PharmacyViewModel : INotifyPropertyChanged
    {
        private string inputedMedicineName;
        public string InputedMedicineName
        {
            get { return inputedMedicineName; }
            set
            {
                inputedMedicineName = value;
                var medicinesWithName = pharmacy.GetMedicinesByName(inputedMedicineName);
                Medicines = medicinesWithName.ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string inputedSymptomToUse;
        public string InputedSymptomToUse
        {
            get { return inputedSymptomToUse; }
            set
            {
                inputedSymptomToUse = value;
                Medicines = pharmacy.GetMedicinesBySymptomsToUse(inputedSymptomToUse).ToList();
            }
        }

        private List<Medicine> medicines;
        public List<Medicine> Medicines
        {
            get { return medicines; }
            set
            {
                medicines = value;
                NotifyPropertyChanged();
            }
        }

        private Medicine selectedMedicine;
        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                selectedMedicine = value;
                AnalogueMedicines = pharmacy.GetAnalogues(selectedMedicine);
            }
        }

        private IEnumerable<Medicine> analogueMedicines;
        public IEnumerable<Medicine> AnalogueMedicines
        {
            get { return analogueMedicines; }
            set
            {
                analogueMedicines = value;
                NotifyPropertyChanged();
            }
        }

        private Pharmacy pharmacy;

        public PharmacyViewModel()
        {
            pharmacy = new Pharmacy(new List<Medicine>
            {
                new Medicine("Варфарин Никомед", 125,
                             new List<string> {"Варфарин натрия", "Кальция гидрофосфата дигидрат", "Индигокармин", "Магния стеарат"},
                             new List<string> { "Острый и рецидивирующий венозный тромбоз", "Эмболия легочной артерии", "Профилактика послеоперационных тромбозов"}),
                new Medicine("Коделак", 78,
                             new List<string> { "Кодеин", "Натрия гидрокарбонат", "Солодки корни", "Термопсиса ланцетного трава"},
                             new List<string> { "Кашель" }),
                new Medicine("Тромбо АСС", 52,
                             new List<string> { "Ацетилсалициловая кислота", "Лактоза моногидрат", "Кремния диоксид коллоидный" },
                             new List<string> { "Стенокардия", "Профилактика тромбоэмболии", "Профилактика тромбоза глубоких вен"}),
                new Medicine("Анопирин", 286,
                             new List<string> {"Ацетилсалициловая кислота", "Карбонат кальция", "Лактоза моногидрат"},
                             new List<string> { "Боли", "Лихорадочные состояния", "Ревматизм"}),
                new Medicine("Аспинат", 110,
                             new List<string> {"Ацетилсалициловая кислота", "Крахмал", "Кремния диоксид коллоидный", "Кислота стеариновая"},
                             new List<string> { "Нестабильная стенокардия", "Профилактика инсульта", "Профилактика тромбоэмболии"})
            });
            Medicines = pharmacy.Medicines.ToList();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
