using BLL.IServices;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class TransactionsBL : BaseBL, ITransactionsBL
    {
        public TransactionsBL(IUnitOfWork unit) : base(unit)
        {
        }
        public async Task CreateTransaction(decimal amount, decimal oldBalance, decimal newBalance, int accountId)
        {
            var newTransaction = new Transaction()
            {
                CurrentAccountId = accountId,
                CreatedDate = DateTime.UtcNow,
                NewBalance = oldBalance + newBalance,
                OldBalance = oldBalance,
                TransactionAmount = amount,
            };
            await _uow.TransactionRepo.Create(newTransaction);
        }
    }
}
