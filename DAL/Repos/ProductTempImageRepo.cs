
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProductTempImageRepo : GenericRepos<ProductTempImage>, IProductTempImageRepo
    {
         public ProductTempImageRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
