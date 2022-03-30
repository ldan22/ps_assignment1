using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message = "Model not valid"): base(message)
        {

        }
    }
}
