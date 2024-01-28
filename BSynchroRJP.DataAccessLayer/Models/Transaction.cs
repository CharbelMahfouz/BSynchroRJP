using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.DataAccessLayer.Models
{
    [BsonCollection("Transactions")]
    public class Transaction : Document
    {
        public decimal Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public ObjectId? CurrentAccountId { get; set; }
    }
}
