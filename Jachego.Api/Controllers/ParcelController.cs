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
    public class ParcelController : Controller
    {
        private readonly IParcelRepository _repository;

        public ParcelController(IParcelRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return _repository.GetParcels();
        }

        [HttpGet("{id}")]
        public Parcel Get(string code)
        {
            return _repository.GetParcelByCode(code);
        }

        [HttpPost]
        public void Post([FromBody]Parcel parcel)
        {
            try
            {
                _repository.Save(parcel);
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
