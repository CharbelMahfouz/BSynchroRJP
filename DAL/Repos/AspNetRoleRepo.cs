
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class AspNetRoleRepo : GenericRepos<AspNetRole>, IAspNetRoleRepo
    {
         public AspNetRoleRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
