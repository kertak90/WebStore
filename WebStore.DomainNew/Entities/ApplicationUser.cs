using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    [Table("Users")]
    public class ApplicationUser : IBaseEntity
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronomic { get; set; }
        public int Age { get; set; }
        public DateTime BornDate { get; set; }
        public bool Male { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
