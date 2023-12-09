
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProductVariationRepo : GenericRepos<ProductVariation>, IProductVariationRepo
    {
         public ProductVariationRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
