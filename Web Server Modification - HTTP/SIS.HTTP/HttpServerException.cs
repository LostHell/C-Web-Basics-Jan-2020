using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP
{
    public class HttpServerException : Exception
    {
        public HttpServerException(string message)
        : base(message)
        {

        }
    }
}
