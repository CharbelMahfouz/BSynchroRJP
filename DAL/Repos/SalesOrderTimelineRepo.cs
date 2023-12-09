
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class SalesOrderTimelineRepo : GenericRepos<SalesOrderTimeline>, ISalesOrderTimelineRepo
    {
         public SalesOrderTimelineRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
