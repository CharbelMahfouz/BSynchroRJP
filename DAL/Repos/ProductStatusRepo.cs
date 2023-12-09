
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProductStatusRepo : GenericRepos<ProductStatus>, IProductStatusRepo
    {
         public ProductStatusRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
