using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Infrastructure.BusinessLogic.Abstractions;
using WebApiCore.Infrastructure.BusinessLogic;
using WebApiCore.Models;
using System.Net.Http;
using System.Net;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        #region Properties

        private IAddressManager _addressManager;
        private IAddressManager AddressManager
        {
            get
            {
                if (_addressManager == null)
                    _addressManager = new AddressManager();

                return _addressManager;
            }
            set
            {
                _addressManager = value;
            }
        }

        #endregion

        // GET: api/address
        [HttpGet]
        public IList<Address> Get()
        {
            return AddressManager.GetAll();
        }

        // GET api/address/5
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return new Address();
            //return AddressManager.Get(id);
        }

         // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Address value)
        {
            AddressManager.Add(value);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Address value)
        {
            AddressManager.Update(value);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/1/2
        [HttpDelete("{buyerId}/{id}")]
        public HttpResponseMessage Delete(int buyerId, int id)
        {
            AddressManager.Delete(buyerId, id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
