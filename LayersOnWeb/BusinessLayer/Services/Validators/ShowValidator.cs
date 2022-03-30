using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;

namespace BusinessLayer
{
    public class ShowValidator : IShowValidator
    {
        public bool validate(ShowModel show)
        {
            if(show.NumberOfTickets <= 0)
            {
                return false;
            }

            if(show.Title.Length < 3)
            {
                return false;
            }

            if(show.Date < DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}
