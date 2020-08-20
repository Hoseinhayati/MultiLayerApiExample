using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiExample.Web.Models;
using WebApiExample.Web.Repositories;

namespace WebApiExample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CustomerRepository _customer;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _customer = new CustomerRepository();
        }

        public IActionResult Index()
        {
            return View(_customer.GetAllCustomer());
        }
    }
}
