using BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    public class AccessRightItem
    {
        public string AccessRightName
        {
            get { return operationType.ToString(); }
        }

        public bool AccessRightSet
        {
            get { return operationAccessRight.HasFlag(operationType); }
            set
            {
                if (value)
                    operationAccessRight |= operationType;
                else
                    operationAccessRight &= ~operationType;
            }
        }

        private static OperationType operationAccessRight;

        public static OperationType OperationAccessRight
        {
            get { return operationAccessRight; }
        }

        private readonly OperationType operationType;

        public AccessRightItem(OperationType opTypeName)
        {
            operationType = opTypeName;
        }
    }
}
