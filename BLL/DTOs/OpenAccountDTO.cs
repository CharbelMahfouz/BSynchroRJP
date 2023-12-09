using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OpenAccountDTO
    {
        public int CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }
}
