using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace PetProjectMarket.Shared.Helpers
{
    public class SortHelpers<T> : ISortHelpers<T>
    {
        public IQueryable<T> ApplySort(ref IQueryable<T> collection, string parametr)
        {
            if (!collection.Any())
                return collection;

            if (string.IsNullOrWhiteSpace(parametr))
                return collection;

            var paramsQuery = parametr.Trim().Split(',');
            var propertiesInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var QueryBilder = new StringBuilder();

            foreach (var param in paramsQuery)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propFromQuery = param.Split(" ")[0];
                var propFromObject = propertiesInfo.FirstOrDefault(p => p.Name.Equals(propFromQuery, StringComparison.InvariantCultureIgnoreCase));

                if (propFromObject is null)
                    continue;

                var sortorder = param.EndsWith("desc") ? "descending" : "ascending";

                QueryBilder.Append($"{propFromObject.Name} {sortorder},");
            }

            string ordering = QueryBilder.ToString().TrimEnd(',', ' ');
            return collection.OrderBy(ordering);
        }
    }
}
