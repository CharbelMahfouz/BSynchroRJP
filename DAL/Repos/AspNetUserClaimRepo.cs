
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class AspNetUserClaimRepo : GenericRepos<AspNetUserClaim>, IAspNetUserClaimRepo
    {
         public AspNetUserClaimRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
