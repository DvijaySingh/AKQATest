using System.ComponentModel.DataAnnotations;

namespace AKQA.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Please Enter Name") ]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Number")]
        [Display(Name ="Number")]
        public decimal Salary { get; set; }
        public string SalaryString { get; set; }
    }
}
