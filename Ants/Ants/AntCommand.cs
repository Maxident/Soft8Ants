using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ants
{
    class AntCommand
    {
        String com, op1, op2, op3, op4, op5;
        public AntCommand(String Com, String Op1, String Op2, String Op3, String Op4, String Op5)
        {
            com = Com;
            op1 = Op1;
            op2 = Op2;
            op3 = Op3;
            op4 = Op4;
            op5 = Op5;
        }
        public String get(int select)
        {
            if (select == 0)
            {
                return com;
            }
            else if (select == 1)
            {
                return op1;
            }
            else if (select == 2)
            {
                return op2;
            }
            else if (select == 3)
            {
                return op3;
            }
            else if (select == 4)
            {
                return op4;
            }
            else if (select == 5)
            {
                return op5;
            }
            return null;
        }
    }
}
