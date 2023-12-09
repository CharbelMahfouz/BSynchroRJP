using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
