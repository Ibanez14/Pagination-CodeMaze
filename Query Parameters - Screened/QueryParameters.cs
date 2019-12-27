using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagin_Codemaze.Query_Parameters
{
    public class QueryParameters
    {
        private int _pageNumber  = 1;
        private int _pageSize = 10;
        const int MaxPageSize  = 50;
        

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value > 1 ? value : 1;
        }
       
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
        }

        public int PreviousPage
        {
            get => PageNumber - 1;
        }

    }
}
