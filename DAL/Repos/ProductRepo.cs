using DAL.Data;
using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo : GenericRepos<Product>, IProductRepo
    {
        public ProductRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
