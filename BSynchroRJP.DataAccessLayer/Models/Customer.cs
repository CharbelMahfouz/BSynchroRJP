using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.DataAccessLayer.Models
{
    [BsonCollection("Customers")]
    public class Customer : Document
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Balance { get; set; }
        public ObjectId? CurrentAccountId { get; set; }
    }
}
