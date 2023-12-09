
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class StockManagementInventoryRepo : GenericRepos<StockManagementInventory>, IStockManagementInventoryRepo
    {
         public StockManagementInventoryRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
