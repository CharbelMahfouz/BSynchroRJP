using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Accounts.Domain.DTOs
{
    public class OpenAccountDTO
    {
        public string CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }
}
