
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class AspNetUserRepo : GenericRepos<AspNetUser>, IAspNetUserRepo
    {
         public AspNetUserRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
