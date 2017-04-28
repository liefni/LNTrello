using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNTrello.Models.Repositories
{


    public class UnauthorisedException : Exception
    {
        public UnauthorisedException()
            :base()
        {

        }

        public UnauthorisedException(string message)
            :base(message)
        {

        }

        public UnauthorisedException(string message, Exception innerException)
            :base(message, innerException)
        {

        }

        
    }
}