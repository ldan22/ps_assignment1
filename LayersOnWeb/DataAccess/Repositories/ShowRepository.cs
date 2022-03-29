using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;

namespace DataAccess
{
    public class ShowRepository : BaseRepository<Show>, IShowRepository
    {
        public ShowRepository(AppDbContext context) : base(context)
        {
        }
    }
}
