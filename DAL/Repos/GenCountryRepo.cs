
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class GenCountryRepo : GenericRepos<GenCountry>, IGenCountryRepo
    {
         public GenCountryRepo(ChrisCellDbContext context) : base(context)
        {
        }
    }
}
