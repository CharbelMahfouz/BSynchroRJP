
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class StockManagementRestockOrderItemRepo : GenericRepos<StockManagementRestockOrderItem>, IStockManagementRestockOrderItemRepo
    {
         public StockManagementRestockOrderItemRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
