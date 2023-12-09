
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class CrmCompanyRepo : GenericRepos<CrmCompany>, ICrmCompanyRepo
    {
         public CrmCompanyRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
