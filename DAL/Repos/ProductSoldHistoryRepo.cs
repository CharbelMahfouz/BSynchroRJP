
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProductSoldHistoryRepo : GenericRepos<ProductSoldHistory>, IProductSoldHistoryRepo
    {
         public ProductSoldHistoryRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
