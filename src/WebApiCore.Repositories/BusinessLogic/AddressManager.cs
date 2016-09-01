using WebApiCore.Infrastructure.Abstractions;
using WebApiCore.Infrastructure.BusinessLogic.Abstractions;
using WebApiCore.Models;
using WebApiCore.Repositories;

namespace WebApiCore.Infrastructure.BusinessLogic
{
    public class AddressManager : Manager<AddressRepository, Address>, IAddressManager
    {
        #region Properties

        private IAddress _addressRepository;
        private IAddress AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                    _addressRepository = new AddressRepository();

                return _addressRepository;
            }
            set
            {
                _addressRepository = value;
            }
        }

        #endregion

        public Address Get(int buyerId, int id)
        {
            return AddressRepository.Get(buyerId, id);
        }

        public void Delete(int buyerId, int id)
        {
            AddressRepository.Delete(buyerId, id);
        }
    }
}
