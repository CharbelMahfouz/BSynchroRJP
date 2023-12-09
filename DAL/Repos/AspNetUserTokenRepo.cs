
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class AspNetUserTokenRepo : GenericRepos<AspNetUserToken>, IAspNetUserTokenRepo
    {
         public AspNetUserTokenRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
