using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public abstract class Operation
    {
        public Account Account { get; }
        public OperationType OperationType { get; } = OperationType.Nothing;
        
        protected Operation(Account account, OperationType opType)
        {
            Account = account;
            OperationType = opType;
        }

        public bool RunOperation(Employee responsibleEmployee, out string outMsg)
        {
            if (CheckOperationAccesRight(responsibleEmployee))
            {
                return RunReqiuredOperation(responsibleEmployee, out outMsg);
            }
            else
            {
                outMsg = $"Сотрудник {responsibleEmployee.Name} {responsibleEmployee.Surname} не имеет прав для выполнения данной операции!";
                return false;
            }
        }

        protected abstract bool RunReqiuredOperation(Employee responsibleEmployee, out string outMsg);

        protected virtual bool CheckOperationAccesRight(Employee responsibleEmployee)
            => (responsibleEmployee.AccessRight & OperationType) == OperationType;
    }
}
