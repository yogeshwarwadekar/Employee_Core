using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.JWT
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
