using Pagin_Codemaze.Query_Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagin_Codemaze.Data
{
   
    public class Repository
    {
        private List<Product> products;

        public Repository()
        {
            products = new List<Product>();

            for (int i = 0; i < 1000; i++)
                products.Add(new Product() { Id = i });
            
        }

        public List<Product> GetProducts(QueryParameters query)
        {
            int toSkip = (query.PageNumber - 1) * query.PageSize;
            // or
            toSkip = query.PreviousPage * query.PageSize;

            int toTake = query.PageSize;

            // doent throw exception if you skip 100000 and take 10000
            return products.Skip(toSkip)
                           .Take(toTake)
                           .ToList();
        }


        public PagedList<Product> GetProducts_Refined(QueryParameters ownerParameters)
        {
            return PagedList<Product>.ToPagedList(products.OrderBy(on => on.Id),
                ownerParameters.PageNumber,
                ownerParameters.PageSize);
        }



    }
}
