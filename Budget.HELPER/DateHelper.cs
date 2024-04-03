using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;

namespace Budget.HELPER
{
    public static class DateHelper
    {
        public static DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            DateTime firstDayOfNextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1);
            return firstDayOfNextMonth.AddDays(-1);
        }

        public static string GetLabelMonthShort(string monthNumber)
        {
            switch (monthNumber)
            {
                case "01":
                    return "Jan";
                case "02":
                    return "Fev";
                case "03":
                    return "Mar";
                case "04":
                    return "Avr";
                case "05":
                    return "Mai";
                case "06":
                    return "Jui";
                case "07":
                    return "Juil";
                case "08":
                    return "Aou";
                case "09":
                    return "Sep";
                case "10":
                    return "Oct";
                case "11":
                    return "Nov";
                case "12":
                    return "Dec";
                default:
                    throw new Exception("No Month for this");
            }
        }

        public static DateRange GetDateRange(MonthYear monthYear)
        {
            DateTime dateMin;
            DateTime dateMax;
            if (monthYear.Month.Id == (int)EnumMonth.BalanceSheetYear)
            {
                dateMin = Convert.ToDateTime($"01/01/{monthYear.Year}");
                dateMax = Convert.ToDateTime($"31/12/{monthYear.Year}");
            }
            else
            {
                dateMin = Convert.ToDateTime($"01/{monthYear.Month.Id}/{monthYear.Year}");
                dateMax = GetLastDayOfMonth(dateMin);
            }

            return new DateRange
            {
                DateMin = dateMin,
                DateMax = dateMax
            };
        }

        public static List<Select> GetMonthList()
        {
            List<Select> monthList = new List<Select>();
            for (int i = 1; i <= 12; i++)
            {
                 monthList.Add(new Select { Id = i, Label = GetLabelMonthShort(i.ToString("00")) });
            }


            return monthList;
        }

        //public static int? CalculateAge(this DateTime? theDateTime)
        //{
        //    int? age = null;
        //    if (theDateTime.HasValue)
        //    {
        //        age = DateTime.Today.Year - theDateTime.Value.Year;
        //        if (theDateTime.Value.AddYears(age.Value) > DateTime.Today)
        //            age--;
        //    }

        //    return age;
        //}
    }



    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());

        public static Singleton Instance { get { return lazy.Value; } }

        private Singleton()
        {
        }
    }


}
