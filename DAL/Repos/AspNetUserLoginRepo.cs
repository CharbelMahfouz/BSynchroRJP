
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class AspNetUserLoginRepo : GenericRepos<AspNetUserLogin>, IAspNetUserLoginRepo
    {
         public AspNetUserLoginRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
