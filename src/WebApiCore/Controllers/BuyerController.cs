using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Infrastructure.BusinessLogic.Abstractions;
using WebApiCore.Models;
using WebApiCore.Infrastructure.BusinessLogic;
using System.Net.Http;
using System.Net;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class BuyerController : Controller
    {
        #region Properties

        private IManager<Buyer> _manager;
        private IManager<Buyer> Manager
        {
            get
            {
                if (_manager == null)
                    _manager = new BuyerManager();

                return _manager;
            }
            set
            {
                _manager = value;
            }
        }

        #endregion

        // GET api/<controller>
        [HttpGet]
        public IList<Buyer> Get()
        {
            return Manager.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Buyer Get(int id)
        {
            return new Buyer();
            //return Manager.Get(id);
        }

        // PUT api/<controller>
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Buyer value)
        {
            Manager.Add(value);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/1
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            Manager.Delete(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
