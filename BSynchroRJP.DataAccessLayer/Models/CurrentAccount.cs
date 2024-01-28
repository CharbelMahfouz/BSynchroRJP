using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.DataAccessLayer.Models
{
    [BsonCollection("CurrentAccount")]
    public class CurrentAccount : Document
    {
        public decimal Balance { get; set; }
        //public List<Transaction> Transactions { get; set; }
    }
}
