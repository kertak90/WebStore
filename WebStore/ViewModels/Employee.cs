using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage ="Имя обязательное поле")]
        [Display(Name ="Имя")]
        [StringLength( maximumLength:200,ErrorMessage ="В имени не может быть больше 200 символов", MinimumLength=2)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия обязательное поле")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        
        [Display(Name = "Отчество")]
        public string Patronomic { get; set; }
        
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        public DateTime BornDate { get; set; }
        public bool Male { get; set; }
    }
}
