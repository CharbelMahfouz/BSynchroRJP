
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProductImageRepo : GenericRepos<ProductImage>, IProductImageRepo
    {
         public ProductImageRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
