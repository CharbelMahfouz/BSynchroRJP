using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Common.Response
{
    public class BaseResponse<TData> where TData : class 
    {
        public int Result { get; set; }
        public string Message { get; set; }
        public TData? Data { get; set; }
    }
}
