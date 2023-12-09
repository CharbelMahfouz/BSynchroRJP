
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class SalesOrderRepo : GenericRepos<SalesOrder>, ISalesOrderRepo
    {
         public SalesOrderRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
