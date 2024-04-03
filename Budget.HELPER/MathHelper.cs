using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.HELPER
{
    public static class MathHelper
    {
        public static double RoundIt(double value,int decimalCount)
        {
            return Math.Round(value, decimalCount);
        }

    }
}
