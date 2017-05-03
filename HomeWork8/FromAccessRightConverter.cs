using BankSystem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HomeWork8
{
    class FromAccessRightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is OperationType)
            {
                var opType = (OperationType)value;
                StringBuilder opTypeSb = new StringBuilder();
                if (opType.HasFlag(OperationType.AddMoney) && opType.HasFlag(OperationType.WithdrawMoney))
                {
                    opTypeSb.Append("Добавление/снятие средств. ");
                }
                else
                {
                    if (opType.HasFlag(OperationType.WithdrawMoney))
                        opTypeSb.Append("Снятие средств. ");
                    if (opType.HasFlag(OperationType.AddMoney))
                        opTypeSb.Append("Добавление средств. ");
                }

                if (opType.HasFlag(OperationType.CreateAccount) && opType.HasFlag(OperationType.RemoveAccount))
                {
                    opTypeSb.Append("Открытие/закрытие счета.");
                }
                else
                {
                    if (opType.HasFlag(OperationType.RemoveAccount))
                        opTypeSb.Append("Закрытие счета.");
                    if (opType.HasFlag(OperationType.CreateAccount))
                        opTypeSb.Append("Открытие счета.");
                }
                return opTypeSb.ToString();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}
