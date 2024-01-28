using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Common.Messaging.Commands
{
    public class CreateTransaction
    {
        public Guid CommandId { get; set; }
        public decimal Amount { get; set; }
        public string CurrentAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
