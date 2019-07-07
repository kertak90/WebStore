using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesData _employees;

        public EmployeeController(IEmployeesData employees)
        {
            _employees = employees;
        }
        [Route("all")]
        public IActionResult Index()
        {
            //return Content("12345");
            return View(_employees.GetAll());
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var employee = _employees.GetById(id);
            if (ReferenceEquals(employee, null)) return NotFound();
            return View(employee);
        }

        [HttpGet]
        //[Route("{edit/id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View(new Employee());
            }

            Employee model = _employees.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        //Не работает маршрутизация приведенная на занятии с id
        [HttpPost]
        //[Route("{Edit/id?}")]
        public IActionResult Edit(Employee model)
        {
            if (model.Id > 0)
            {
                var dbItem = _employees.GetById(model.Id);

                if (dbItem == null) return NotFound();

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Male = model.Male;
                
            }
            {
                _employees.AddNew(model);
            }
            _employees.Commit();
            return RedirectToAction(nameof(Index));
        }
        
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            _employees.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}