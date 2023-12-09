
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class GenCrmCompanyTypeRepo : GenericRepos<GenCrmCompanyType>, IGenCrmCompanyTypeRepo
    {
         public GenCrmCompanyTypeRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
