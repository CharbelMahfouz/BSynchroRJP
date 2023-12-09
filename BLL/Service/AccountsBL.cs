using BLL.DTOs;
using BLL.IServices;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AccountsBL : BaseBL, IAccountsBL
    {
        private readonly ITransactionsBL _transactionsBL;
        public AccountsBL(IUnitOfWork unit, ITransactionsBL transactionsBL) : base(unit)
        {
            _transactionsBL = transactionsBL;
        }
        public async Task<ResponseModel> OpenAccount(OpenAccountDTO model)
        {
            var customer = await _uow.CustomerRepo.GetById(model.CustomerId);
            if (customer == null)
            {
                return CreateResponseModel(0, "Customer not found", string.Empty);
            }
            bool hasExistingAccount = await _uow.CurrentAccountRepo.CheckIfExists(x => x.CustomerId == model.CustomerId);
            if (hasExistingAccount)
            {
                return CreateResponseModel(0, "Customer already has an account open", string.Empty);
            }
            customer.Balance = model.InitialCredit;
            var newAccount = new CurrentAccount()
            {
                CustomerId = model.CustomerId,
                Balance = model.InitialCredit,
                CreatedDate = DateTime.UtcNow,

            };
            await _uow.CurrentAccountRepo.Create(newAccount);
            if (model.InitialCredit != 0)
            {
                decimal oldBalance = 0;
                decimal newBalance = model.InitialCredit;
                await _transactionsBL.CreateTransaction(model.InitialCredit, oldBalance, newBalance, newAccount.Id);
            }
            return CreateResponseModel(1, "Account opened successfully", string.Empty);
        }
    }
}
