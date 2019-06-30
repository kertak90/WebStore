using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{    
    public class HomeController : Controller
    {
        List<Employee> myEmployees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Age = 22
            },
            new Employee
            {
                Id = 1,
                FirstName = "Петр",
                SurName = "Петров",
                Age = 27
            },
            new Employee
            {
                Id = 1,
                FirstName = "Сидор",
                SurName = "Сидоров",
                Age = 12
            }
        };
        public IActionResult Index()
        {
            //return Content("12345");
            return View(myEmployees) ;
        }

        public IActionResult Details(int id)
        {
            //return Content("12345");
            return View(myEmployees.FirstOrDefault(p => p.Id == id));
        }
    }
}