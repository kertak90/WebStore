using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronomic { get; set; }
        public int Age { get; set; }
        public DateTime BornDate { get; set; }
        public bool Male { get; set; }
    }
}
