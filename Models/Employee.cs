using System.ComponentModel.DataAnnotations;

namespace CRUD_OPERATION_2.Models
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }

        [Display(Name ="Employee Name")]
        [Required (ErrorMessage ="Employee Name is required")]
        public String emp_name { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }
    }
}
