using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.HELPER
{
    public static class ChartHelper
    {
        public static string GetChartColor(string Color)
        {
            switch (Color)
            {
                case "Red":
                    return "#DC2C18";
                case "Green":
                    return "#4CAF50";
                default:
                    return "#DEE1E6";
            }
        }
    }
}
