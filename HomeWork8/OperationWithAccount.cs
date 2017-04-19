using BankSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    class OperationWithAccount : Operation
    {
        public OperationWithAccount(Account account, OperationType opType, double moneyAmount) : base (account, opType, moneyAmount)
        { }

        public ObservableCollection<OperationType> OperationTypes { get; } = new ObservableCollection<OperationType>(Enum.GetValues(typeof(OperationType))
                                                                                                                         .Cast<OperationType>());
    }
}
