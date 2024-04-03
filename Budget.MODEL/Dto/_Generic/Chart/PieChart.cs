using System.Collections.Generic;

namespace Budget.MODEL.Dto
{
    public class PieChart
    {
        public bool Legend { get; set; }
        public bool ExplodeSlices { get; set; }
        public bool Labels { get; set; }
        public bool Doughnut { get; set; }
        public bool Gradient { get; set; }
        public Scheme Scheme { get; set; }

        public PieChart()
        {
            Legend = false;
            ExplodeSlices = true;
            Labels = true;
            Doughnut = false;
            Gradient = true;

            Scheme = new Scheme();
        }
    }

    public class Scheme
    {
        public List<string> Domain { get; set; }

        public Scheme()
        {
            Domain = new List<string>();
        }
    }

    public class DataPieChart
    {
        public string Title { get; set; }
        public ComboNameValueMultiple<SelectNameValueGroupDto<double>, double> Ranges { get; set; }
        public List<SelectNameValueDto<double>> MainChart { get; set; }
    }


}
