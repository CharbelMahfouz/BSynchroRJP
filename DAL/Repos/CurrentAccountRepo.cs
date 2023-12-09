
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class CurrentAccountRepo : GenericRepos<CurrentAccount>, ICurrentAccountRepo
    {
         public CurrentAccountRepo(BSynchroRJPDbContext context) : base(context)
        {
        }
    }
}
