
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ApiDataLoggingRepo : GenericRepos<ApiDataLogging>, IApiDataLoggingRepo
    {
         public ApiDataLoggingRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
