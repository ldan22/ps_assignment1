using DataAccess.Contracts;

namespace BusinessLayer.Contracts
{
    public interface IShowMapper
    {
        ShowModel Map(Show show);
        Show Map(ShowModel showModel);
    }
}
