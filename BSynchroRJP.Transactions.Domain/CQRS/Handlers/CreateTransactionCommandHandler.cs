using BSynchroRJP.DataAccessLayer.IRepositories;
using BSynchroRJP.DataAccessLayer.Models;
using BSynchroRJP.Transactions.Domain.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Transactions.Domain.CQRS.Handlers
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
    {
        private readonly IGenericRepository<Transaction> _transactionRepo;

        public CreateTransactionCommandHandler(IGenericRepository<Transaction> transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction()
            {
                Amount = request.Amount,
                CurrentAccountId = new MongoDB.Bson.ObjectId(request.CurrentAccountId),
                TransactionDate = request.TransactionDate,


            };
            await _transactionRepo.InsertOneAsync(transaction);
        }
    }
}
