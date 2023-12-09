
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class AspNetRoleClaimRepo : GenericRepos<AspNetRoleClaim>, IAspNetRoleClaimRepo
    {
         public AspNetRoleClaimRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
