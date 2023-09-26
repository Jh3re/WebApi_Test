using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DataContract
{
    public class Response
    {
        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }

        
    }
}