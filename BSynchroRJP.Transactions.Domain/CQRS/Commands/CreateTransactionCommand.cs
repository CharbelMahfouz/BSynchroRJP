using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Transactions.Domain.CQRS.Commands
{
    public class CreateTransactionCommand : IRequest
    {
        public decimal Amount { get; set; }
        public string CurrentAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
