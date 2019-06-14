using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jachego.Domain.Shipping.Entities;
using Jachego.Domain.Shipping.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jachego.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarrierController : Controller
    {
        private readonly ICarrierRepository _repository;

        public CarrierController(ICarrierRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Carrier> Get()
        {
            return _repository.GetCarriers();
        }

        [HttpGet("{id}")]
        public Carrier Get(int id)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(id).CopyTo(bytes, 0);
            var newId = new Guid(bytes);

            return _repository.GetById(newId);
        }

        [HttpPost]
        public void Post([FromBody]Carrier carrier)
        {
            try
            {
                _repository.Save(carrier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
