using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
<<<<<<< Updated upstream
using LibApp.Models;
=======
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.AspNetCore.Authorization;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< Updated upstream
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
=======
using System.Threading.Tasks;
using System.Web.Http;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
>>>>>>> Stashed changes
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<< Updated upstream
    public class CustomersController : ControllerBase
    {
        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
=======
    [Authorize(Roles = "Owner,StoreManager")]
    public class CustomersController : ControllerBase
    {
        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            this.repository = repository;
>>>>>>> Stashed changes
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
<<<<<<< Updated upstream
            var customers = _context.Customers
                                        .Include(c => c.MembershipType)
                                        .ToList()
                                        .Select(_mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Console.WriteLine("START REQUEST");
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            await Task.Delay(2000);
            if (customer == null)
            {
                return NotFound();
            }
            
            Console.WriteLine("END REQUEST");
=======
            var customers = repository.GetCustomers()
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customers);
        }


        // GET /api/customers/{id}
        [HttpGet("{id}", Name ="GetCustomer")]
        public IActionResult GetCustomer(string id)
        {
            var customer = repository.GetCustomerById(id);
            if (customer == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

>>>>>>> Stashed changes
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers
<<<<<<< Updated upstream
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT /api/customers/{id}
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
        }

        // DELETE /api/customers
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

        private ApplicationDbContext _context;
=======
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(customerDto);
            customer.Id = Guid.NewGuid().ToString();
            repository.AddCustomer(customer);
            repository.Save();

            customerDto.Id = customer.Id;
        
            return CreatedAtRoute(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
        }

        // PUT /api/customers/{id}
        [Authorize(Roles = "Owner")]
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(string id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var customerInDb = repository.GetCustomerById(id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            _mapper.Map(customerDto, customerInDb);

            repository.UpdateCustomer(customerInDb);
            repository.Save();

            return Ok(customerInDb);
        }

        // DELETE /api/customers/{id}
        [Authorize(Roles = "Owner")]
        [HttpDelete("{id}")]
        public void DeleteCustomer(string id)
        {
            var customerInDb = repository.GetCustomerById(id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            repository.DeleteCustomer(id);
            repository.Save();
        }

        private readonly ICustomerRepository repository;
>>>>>>> Stashed changes
        private readonly IMapper _mapper;
    }
}
