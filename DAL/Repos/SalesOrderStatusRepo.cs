
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class SalesOrderStatusRepo : GenericRepos<SalesOrderStatus>, ISalesOrderStatusRepo
    {
         public SalesOrderStatusRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
