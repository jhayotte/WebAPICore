using WebApiCore.Models;

namespace WebApiCore.Infrastructure.Abstractions
{
    public interface IAddress : IRepository<Address>
    {
        Address Get(int buyerId, int id);

        void Delete(int buyerId, int id);
    }
}
