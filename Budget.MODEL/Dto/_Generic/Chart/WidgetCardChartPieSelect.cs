using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class WidgetCardChartPieSelect
    {
        public PieChart PieChart { get; set; }
        public DataPieChart Data { get; set; }
        public bool IsLoaded { get; set; }

        public WidgetCardChartPieSelect(string title)
        {
            PieChart = new PieChart();
            Data = new DataPieChart();


            Data.Title = title;
            Data.Ranges = new ComboNameValueMultiple<SelectNameValueGroupDto<double>, double>();
        }
    }

    
}
