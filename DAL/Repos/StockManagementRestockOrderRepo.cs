
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class StockManagementRestockOrderRepo : GenericRepos<StockManagementRestockOrder>, IStockManagementRestockOrderRepo
    {
         public StockManagementRestockOrderRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
