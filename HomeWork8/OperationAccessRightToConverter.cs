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
    class OperationAccessRightToConverter : IValueConverter
    {
        private const string AddWithdrawRight = "Зачисление/снятие средств";
        private const string AddWithdrawCreateRemoveRight = "Зачисление/снятие средств, создание/удаление счета";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((OperationAccessRights)value == OperationAccessRights.AddWithdraw)
                return AddWithdrawRight;
            else
                return AddWithdrawCreateRemoveRight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == AddWithdrawRight)
                return OperationAccessRights.AddWithdraw;
            else
                return OperationAccessRights.AddWithdrawCreateRemove;
        }
    }
}
