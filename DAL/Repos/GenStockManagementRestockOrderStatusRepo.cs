
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class GenStockManagementRestockOrderStatusRepo : GenericRepos<GenStockManagementRestockOrderStatus>, IGenStockManagementRestockOrderStatusRepo
    {
         public GenStockManagementRestockOrderStatusRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
