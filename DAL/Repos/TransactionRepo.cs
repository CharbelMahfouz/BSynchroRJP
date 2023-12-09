
using System.Collections.Generic;
using DAL.Services;
using DAL.Models;
using DAL.Data;

namespace DAL.Repos
{
    public class TransactionRepo : GenericRepos<Transaction>, ITransactionRepo
    {
         public TransactionRepo(BSynchroRJPDbContext context) : base(context)
        {
        }
    }
}
