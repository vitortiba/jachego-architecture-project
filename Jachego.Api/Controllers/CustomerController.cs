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
    public class CustomerController : Controller
    {
        public readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(id).CopyTo(bytes, 0);
            var newId = new Guid(bytes);

            return _repository.GetById(newId);
        }

        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            try
            {
                _repository.Save(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
