
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class SalesOrderItemRepo : GenericRepos<SalesOrderItem>, ISalesOrderItemRepo
    {
         public SalesOrderItemRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
