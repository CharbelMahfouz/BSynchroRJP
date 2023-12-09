
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class CustomerRepo : GenericRepos<Customer>, ICustomerRepo
    {
         public CustomerRepo(BSynchroRJPDbContext context) : base(context)
        {
        }
    }
}
