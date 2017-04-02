using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    interface IRotatable
    {
        void Move(string carModel);
    }

    interface IDoor
    {
        void Open(string carModel);
    }
}
