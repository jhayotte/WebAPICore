using WebApiCore.Models;

namespace WebApiCore.Infrastructure.BusinessLogic.Abstractions
{
    public interface IAddressManager : IManager<Address>
    {
        Address Get(int buyerId, int id);

        void Delete(int buyerId, int id);
    }
}
