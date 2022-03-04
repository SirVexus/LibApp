using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Authorization;
using LibApp.Interfaces;
>>>>>>> Stashed changes

namespace LibApp.Controllers
{
    [Authorize(Roles = "Owner,StoreManager")]
    public class CustomersController : Controller
    {
<<<<<<< Updated upstream
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {          
=======
        private readonly ICustomerRepository repository;
        private readonly IMembershipTypeRepository membershipTypeRepository;

        public CustomersController(ICustomerRepository repository, IMembershipTypeRepository membershipTypeRepository)
        {
            this.repository = repository;
            this.membershipTypeRepository = membershipTypeRepository;
        }

        public ViewResult Index()
        {         
>>>>>>> Stashed changes
            return View();
        }

        public IActionResult Details(string id)
        {
<<<<<<< Updated upstream
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);
=======
            var customer = repository.GetCustomerById(id);
>>>>>>> Stashed changes

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

<<<<<<< Updated upstream
        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
=======
        [Authorize(Roles = "Owner")]
        public IActionResult New()
        {
            var membershipTypes = membershipTypeRepository.GetMembershipTypes().ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
>>>>>>> Stashed changes
            };

            return View("CustomerForm", viewModel);
        }

<<<<<<< Updated upstream
=======
        [Authorize(Roles = "Owner")]
        public IActionResult Edit(string id)
        {
            var customer = repository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = membershipTypeRepository.GetMembershipTypes().ToList()
        };

            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = "Owner")]
>>>>>>> Stashed changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
<<<<<<< Updated upstream
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
=======
                    MembershipTypes = membershipTypeRepository.GetMembershipTypes().ToList()
            };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == null)
            {
                customer.Id = Guid.NewGuid().ToString();
                repository.AddCustomer(customer);
            }
            else
            {
                var customerInDb = repository.GetCustomerById(customer.Id);
>>>>>>> Stashed changes
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
<<<<<<< Updated upstream
            }

            _context.SaveChanges();
=======

                repository.UpdateCustomer(customerInDb);
            }

            try
            {
                repository.Save();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }
>>>>>>> Stashed changes

            return RedirectToAction("Index", "Customers");
        }
    }
}