using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class TicketsOverflowException : Exception
    {
        public TicketsOverflowException()
        {

        }
        public TicketsOverflowException(string message): base(message)
        {

        }
        public TicketsOverflowException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
