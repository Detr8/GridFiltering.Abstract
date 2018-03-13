using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GridFiltering
{
    public abstract class FilterModel<T> where T : class
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public bool IsAscSort { get; set; }

        public string SortField { get; set; }

        //[JsonIgnore]
        protected abstract Dictionary<string, Expression<Func<T, object>>> FieldsMapping { get; }

        //[JsonIgnore]
        public virtual Expression<Func<T, object>> Sorter => !string.IsNullOrEmpty(SortField) && FieldsMapping.ContainsKey(SortField.ToLower()) 
            ? FieldsMapping[SortField.ToLower()] 
            : null;

        //[JsonIgnore]
        public abstract IEnumerable<Expression<Func<T, bool>>> Filters { get; }
    }
}
