using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL
{
    public class AsChartCategorisation
    {
        public AsChartCategorisationSelect Debit { get; set; }
        //public AsChartCategorisationSelect OperationTypeFamily { get; set; }
        //public AsChartCategorisationSelect OperationType { get; set; }
    }

    public class AsChartCategorisationSelect
    {
        public WidgetCardChartPieSelect OperationMethod { get; set; }
        public WidgetCardChartPieSelect OperationTypeFamily { get; set; }
        public WidgetCardChartPieSelect OperationType { get; set; }
    }
}
