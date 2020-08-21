using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiExample.Web.Models;
using WebApiExample.Web.Repositories;
using WebApiExample.Web.ViewModels;

namespace WebApiExample.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CustomerRepository _customer;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,IMapper mapper)
        {
            _logger = logger;
            _customer = new CustomerRepository();
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            string token = User.FindFirst("AccessToken").Value;
            return View(_customer.GetAllCustomer(token));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            var mapModel = _mapper.Map<Customer>(model);
            _customer.AddCustomer(mapModel);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = _customer.GetCustomerById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _customer.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _customer.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
