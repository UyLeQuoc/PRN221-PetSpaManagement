using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Commons
{
    public class PaginationParameter
    {
        private const int maxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}