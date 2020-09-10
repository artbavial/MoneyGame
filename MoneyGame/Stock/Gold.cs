using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoneyGame.Stock
{
    public class Gold
    {
        public int value;

        public override bool Equals(object obj)
        {
            if (obj is Gold gold)
            {
                return value.Equals(gold.value);
            }
            return false;
        }
    }
}
