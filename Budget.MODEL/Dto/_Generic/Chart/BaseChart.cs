using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.MODEL.Dto
{
    public class BaseChartBar
    {
        //public List<DataSet> DataSets { get; set; }
        //public List<Select> Labels { get; set; }
        public ChartData Data { get; set; }
        public Options Options { get; set; }
        //public List<Color> Colors { get; set; }

        public BaseChartBar()
        {
            Data = new ChartData();
            //DataSets = new List<DataSet>();
            //Labels = new List<Select>();
            //Colors = new List<Color>();
            //Options = new Options();
        }
    }

    public class ChartData
    {
        public List<string> Labels { get; set; }
        public List<Dataset> Datasets { get; set; }

        public ChartData()
        {
            Labels = new List<string>();
            Datasets = new List<Dataset>();
        }
    }


    public class Dataset
    {
        public List<double> Data { get; set; }
        public string Label { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> HoverBackgroundColor { get; set; }  
    }




    public class BaseChartData
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        private double _amount;
        public double Amount
        {
            get => Math.Round(_amount,2);
            set => _amount = Math.Round(value, 2);
        }
    }

    public class BaseChart
    {
        public List<DataSet> DataSets { get; set; }
        public List<Select> Labels { get; set; }
        public Options Options { get; set; }
        public List<Color> Colors {get; set; }

        public BaseChart()
        {
            DataSets = new List<DataSet>();
            Labels = new List<Select>();
            Colors = new List<Color>();
            Options = new Options();
        }
    }

    public class DataSet
    {
        public string Label { get; set; }
        public List<double> Data { get; set; }
        public string BackgroundColor { get; set; }
    }
    
    public class Color
    {
        public List<string> BackgroundColor { get; set; }
    }

    public class Options
    {
        public Scales Scales { get; set; }

        public Options()
        {
            Scales = new Scales();
        }
    }

    public class Scales
    {
        public List<YAxe> YAxes { get; set; }

        public Scales()
        {
            YAxes = new List<YAxe>();
        }
    }

    public class YAxe
    {
        public bool Display { get; set; }
        public Tick Ticks { get; set; }

        public YAxe()
        {
            Ticks = new Tick();
            Display = false;
        }
    }

    public class Tick
    {
        public Boolean BeginAtZero { get; set; }
        public Boolean Display { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Steps { get; set; }
        public double StepValue { get; set; }

        public Tick ()
        {
            BeginAtZero = true;
            Display = false;
            Min = 0;
            Max = 0;
            Steps = 10000;
            StepValue = 10000;
            
        }
    }

    public enum EnumChartBarColor
    {
        Red = 1,
        Green = 2
    }

    public enum EnumAmountState
    {
        Credit = 1,
        Debit = 2,
        Balance = 3
    }


}
