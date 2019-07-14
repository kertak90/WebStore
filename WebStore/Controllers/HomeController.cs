using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DAL;
using WebStore.DomainNew.Filters;
using WebStore.Infrastructure;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private WebStoreContext _context;
        public HomeController(WebStoreContext context)
        {
            _context = context;
        }
        [SimpleActionFilter]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult BlogList()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUser user)
        {
            bool nameEmpty = !String.IsNullOrEmpty(user.UserName);
            bool emailEmpty = !String.IsNullOrEmpty(user.UserEmail);
            bool passEmpty = !String.IsNullOrEmpty(user.UserPassword);

            if(nameEmpty && emailEmpty && passEmpty)
            {
                //New User
                _context.ApplicationUsers.Add(new Domain.Entities.ApplicationUser()
                {
                    FirstName = user.UserName,
                    Email = user.UserEmail,
                    Password = user.UserPassword
                });
                _context.SaveChanges();
            }
            else if(nameEmpty && emailEmpty)
            {
                _context.Sessions.Add(new Domain.Entities.Session()
                {

                });
            }
            return View();
        }
    }
}