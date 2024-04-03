//using Budget.MODEL.Dto;
//using Budget.MODEL.Filter;
//using System;
//using System.Collections.Generic;
//using System.Text;

using System;

namespace Budget.SERVICE._Helpers
{
    public static class DateHelper
    {
        //        public static DateTime GetFirstDayOfMonth(DateTime date)
        //        {
        //            return new DateTime(date.Year, date.Month, 1);
        //        }

        //        public static DateTime GetLastDayOfMonth(DateTime date)
        //        {
        //            DateTime firstDayOfNextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1);
        //            return firstDayOfNextMonth.AddDays(-1);
        //        }

        public static int? CalculateAge(this DateTime? theDateTime)
        {
            int? age = null;
            if (theDateTime.HasValue)
            {
                age = DateTime.Today.Year - theDateTime.Value.Year;
                if (theDateTime.Value.AddYears(age.Value) > DateTime.Today)
                    age--;
            }

            return age;
        }

        //        public static string GetLabelMonthShort(string monthNumber)
        //        {
        //            switch (monthNumber)
        //            {
        //                case "01":
        //                    return "Jan";
        //                case "02":
        //                    return "Fev";
        //                case "03":
        //                    return "Mar";
        //                case "04":
        //                    return "Avr";
        //                case "05":
        //                    return "Mai";
        //                case "06":
        //                    return "Jui";
        //                case "07":
        //                    return "Juil";
        //                case "08":
        //                    return "Aou";
        //                case "09":
        //                    return "Sep";
        //                case "10":
        //                    return "Oct";
        //                case "11":
        //                    return "Nov";
        //                case "12":
        //                    return "Dec";
        //                default:
        //                    throw new Exception("No Month for this");
        //            }
        //        }

        //        public static List<MonthYear> GetMonthYearListByYears(List<int> yearList)
        //        {
        //            List<MonthYear> monthYearList = new List<MonthYear>();
        //            foreach(var year in yearList)
        //            {
        //                for(int i=0;i<13;i++)
        //                {
        //                    MonthYear monthYear = new MonthYear { 
        //                        Month = new Select { Id = i, Label = GetLabelMonthShort(string.Format(i.ToString(),"0")) },
        //                        Year = year
        //                    };
        //                    monthYearList.Add(monthYear);
        //                }
        //            }

        //            return monthYearList;
        //        }
    }
}
