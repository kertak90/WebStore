using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    public class InMemoryEmployeeData : IEmployeesData
    {
        private readonly List<Employee> _employees;
        public InMemoryEmployeeData()
        {
            _employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Иван",
                    SurName = "Иванов",
                    Patronomic = "Иванов",
                    Age = 22,
                    Male = true
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Петр",
                    SurName = "Петров",
                    Patronomic = "Петрович",
                    Age = 27,
                    Male = true
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Сидор",
                    SurName = "Сидоров",
                    Patronomic = "Сидорович",
                    Age = 12,
                    Male = true
                }
            };
        }
        public void AddNew(Employee model)
        {
            model.Id = _employees.Max(p => p.Id) + 1;
            _employees.Add(model);
        }

        public void Commit()
        {
            
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if(employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(p => p.Id == id);
        }
    }
}
