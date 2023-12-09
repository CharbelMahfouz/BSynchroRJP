
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProductColorRepo : GenericRepos<ProductColor>, IProductColorRepo
    {
         public ProductColorRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
