using System.Linq;
using WebApiCore.Infrastructure.Abstractions;
using WebApiCore.Models;

namespace WebApiCore.Repositories
{
    public class AddressRepository : Repository<MarketplaceContext, Address>, IAddress
    {
        public Address Get(int buyerId, int id)
        {
            return GetAll().FirstOrDefault(a => a.BuyerId == buyerId && a.Id == id);
        }

        public void Delete(int buyerId, int id)
        {
            var address = Get(buyerId, id);

            Delete(address);
        }
    }
}