using BSynchroRJP.Accounts.Common;
using BSynchroRJP.Accounts.Domain.CQRS.Commands;
using BSynchroRJP.Accounts.Domain.CQRS.Responses;
using BSynchroRJP.Common.Messaging.Commands;
using BSynchroRJP.Common.Messaging.Endpoints;
using BSynchroRJP.DataAccessLayer.IRepositories;
using BSynchroRJP.DataAccessLayer.Models;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Accounts.Domain.CQRS.Handlers
{
    public class OpenAccountAcommandHandler : IRequestHandler<OpenAccountCommand, OpenAccountCommandResponse>
    {
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<CurrentAccount> _currentAccountRepo;
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public OpenAccountAcommandHandler(IGenericRepository<Customer> customerRepo, IGenericRepository<CurrentAccount> currentAccountRepo, IBus bus, IConfiguration configuration)
        {
            _customerRepo = customerRepo;
            _currentAccountRepo = currentAccountRepo;
            _bus = bus;
            _configuration = configuration;
        }

        public async Task<OpenAccountCommandResponse> Handle(OpenAccountCommand request, CancellationToken cancellationToken)
        {
            OpenAccountCommandResponse resp = new OpenAccountCommandResponse();
            var customer = await _customerRepo.FindByIdAsync(request.CustomerId);
            if (customer == null)
            {
                resp.Result = 0;
                resp.Data = "";
                resp.Message = Constants.ErrorMessages.CustomerNotFound;
                return resp;
            }

            bool hasExistingAccount = customer.CurrentAccountId != null;
            if (hasExistingAccount)
            {
                resp.Result = 0;
                resp.Message = Constants.ErrorMessages.CustomerAlreadyHasAccount;
                resp.Data = null;
            }
            customer.Balance = request.InitialCredit;
            var newAccount = new CurrentAccount()
            {
                Balance = request.InitialCredit,
            };
            await _currentAccountRepo.InsertOneAsync(newAccount);
            customer.CurrentAccountId = newAccount.Id;
            await _customerRepo.ReplaceOneAsync(customer);
            if (request.InitialCredit != 0)
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri($"{_configuration["RabbitMqConfig:Host"]}/{Endpoints.CreateTransaction}"));
                await endpoint.Send(new CreateTransaction()
                {
                    Amount = request.InitialCredit,
                    CommandId = Guid.NewGuid(),
                    CurrentAccountId = newAccount.Id.ToString(),
                    TransactionDate = DateTime.UtcNow
                });
            }

            resp.Result = 1;
            resp.Data = customer.Id.ToString();
            resp.Message = Constants.SuccessMessages.CurrentAccountOpened;
            return resp;

        }
    }
}
