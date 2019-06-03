using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMDP_Api
{
    public class SocketErrorException : Exception
    {
        public Exception Exception { get; private set; }
        public String Message { get; private set; }

        public SocketErrorException(Exception exception, string message)
        {
            Exception = exception;
            Message = message;
        }
    }
}
