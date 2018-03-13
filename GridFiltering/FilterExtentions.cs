using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridFiltering
{
    public static class FilterExtentions
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> src, FilterModel<T> filterModel) where T:class
        {
            foreach (var filter in filterModel.Filters)
            {
                src = src.Where(filter);
            }

            return src;
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> src, FilterModel<T> filterModel) where T : class
        {
            var sortExpression = filterModel.Sorter;
            if (sortExpression == null) return src;

            return filterModel.IsAscSort ? src.OrderBy(sortExpression) : src.OrderByDescending(sortExpression);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> src, FilterModel<T> filterModel) where T : class
        {
            return src.Skip((filterModel.PageNumber - 1) * filterModel.PageSize).Take(filterModel.PageSize);
        }
    }
}
