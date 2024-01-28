using BSynchroRJP.Accounts.Domain.CQRS.Responses;
using BSynchroRJP.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Accounts.Domain.CQRS.Commands
{
    public class OpenAccountCommand : IRequest<OpenAccountCommandResponse>
    {
        public string CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }
}
