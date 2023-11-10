using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProjectMarket.Shared.Helpers
{
    public interface ISortHelpers<T>
    {
        IQueryable<T> ApplySort(ref IQueryable<T> collection, string parametr);
    }
}
