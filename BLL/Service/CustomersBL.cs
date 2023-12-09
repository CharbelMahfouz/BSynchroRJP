using BLL.DTOs;
using BLL.IServices;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CustomersBL : BaseBL, ICustomersBL
    {
        public CustomersBL(IUnitOfWork unit) : base(unit)
        {
        }

        public async Task<CustomerDTO> GetCustomerDetails(int customerId)
        {
            var customer = await _uow.CustomerRepo.GetAll(x => x.Id == customerId).Include(x => x.CurrentAccounts).ThenInclude(x => x.Transactions).Select(x => new CustomerDTO
            {
                Id = x.Id,
                Balance = x.Balance ?? 0,
                Name = x.FirstName,
                Surname = x.LastName,
                Transactions = x.CurrentAccounts.SelectMany(x => x.Transactions).Select(t => new TransactionDTO
                {
                    CreatedDate = t.CreatedDate,
                    NewBalance = t.NewBalance ?? 0,
                    OldBalance = t.OldBalance ?? 0,
                    TransactionAmount = t.TransactionAmount ?? 0
                }).ToList()
            }).FirstOrDefaultAsync();
            return customer;
        }
    }
}
