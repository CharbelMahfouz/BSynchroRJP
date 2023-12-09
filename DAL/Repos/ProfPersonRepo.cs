
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class ProfPersonRepo : GenericRepos<ProfPerson>, IProfPersonRepo
    {
         public ProfPersonRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
