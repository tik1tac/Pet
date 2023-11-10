using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProjectMarket.Shared.Helpers
{
    public class PagingResponse<T> where T : class
    {
        public Metadata Metadata { get; set; }
        public List<T> Items { get; set; }
    }
}
