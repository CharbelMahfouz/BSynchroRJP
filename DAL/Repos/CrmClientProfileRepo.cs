
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class CrmClientProfileRepo : GenericRepos<CrmClientProfile>, ICrmClientProfileRepo
    {
         public CrmClientProfileRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
