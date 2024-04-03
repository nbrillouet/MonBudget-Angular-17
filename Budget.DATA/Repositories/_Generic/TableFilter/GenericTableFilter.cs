using Budget.HELPER;
using Budget.MODEL;
using Budget.MODEL.Dto;
using Budget.MODEL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;



namespace Budget.DATA.Repositories
{
    public static class GenericTableFilter
    {
        public static IQueryable<T> GetGenericFilters<T, F>(IQueryable<T> context, F filter)
        {
            var list = filter.GetType().GetProperties();
            var accountStatement = Activator.CreateInstance(typeof(T));// new T();
            var asProperties = accountStatement.GetType().GetProperties();

            foreach (var item in list)
            {
                var value = item.GetValue(filter);
                if (value != null)
                {
                    var reference = asProperties.Where(x => x.Name == item.Name).FirstOrDefault();
                    if (reference != null)
                    {

                        if (value is int || value is int?)
                            context = context.Where($"{item.Name} == {value}");
                        if (value is string)
                        {
                            string label = value.ToString().ToUpper();
                            //context = context.Where($"{item.Name}==\"{value}\"");

                            context = context.Where($"{item.Name}.ToUpper().Contains(\"{label}\")");
                            //context = context.Where($"{item.Name}.StartsWith({label})");

                            //context = context.Where($"@0.Contains({item.Name})", label);
                        }
                        if (value is Select)
                        {
                            Select select = (Select)value;
                            context = context.Where($"Id{item.Name} == {select.Id}");
                        }
                        if (value is List<Select>)
                        {
                            List<Select> t = (List<Select>)value;
                            if (t != null && t.Count > 0)
                            {
                                var ids = t.Select(x => x.Id).ToList();
                                var someId= $"Id{item.Name}";

                                //context = context.Where($"@0.Contains({someId}.Value)", ids);
                                context = context.Where($"@0.Contains({someId})", ids);
                            }
                        }
                        if (value is FilterDateRange)
                        {
                            FilterDateRange filterDateRange = (FilterDateRange)value;
                            if (filterDateRange.DateMin != null)
                            {
                                context = context.Where($"{item.Name} >= {filterDateRange.DateMin}");
                            }
                            if (filterDateRange.DateMax != null)
                            {
                                context = context.Where($"{item.Name} <= {filterDateRange.DateMax}");
                            }
                        }
                        if (value is FilterNumberRange)
                        {
                            FilterNumberRange filterNumberRange = (FilterNumberRange)value;
                            if (filterNumberRange.NumberMin != null)
                            {
                                context = context.Where($"{item.Name} >= {filterNumberRange.NumberMin}");
                            }
                            if (filterNumberRange.NumberMax != null)
                            {
                                context = context.Where($"{item.Name} <= {filterNumberRange.NumberMax}");
                            }
                        }
                    }
                    if (value is MonthYear)
                    {
                        MonthYear monthYear = (MonthYear)value;
                        var date = Convert.ToDateTime($"01/{monthYear.Month.Id}/{monthYear.Year}");
                        var dateMin = DateHelper.GetFirstDayOfMonth(date);
                        var dateMax = DateHelper.GetLastDayOfMonth(date);

                        context = context.Where($"DateIntegration.Value>=@0", dateMin);
                        context = context.Where($"DateIntegration.Value<=@0", dateMax);
                    }
                    if (value is Pagination)
                    {
                        Pagination pagination = (Pagination)value;
                        var fieldsSorted = pagination.SortColumn.Split('-');
                        var columnSorted = String.Join(".", fieldsSorted.Select(o => o.ToString()).ToArray());
                        if (pagination.SortDirection == "asc")
                        {
                            context = context.OrderBy(columnSorted);
                        }
                        else
                        {
                            context = context.OrderByDescending(columnSorted);
                        }
                    }
                }
            }

            return context;
        }
    }
}
