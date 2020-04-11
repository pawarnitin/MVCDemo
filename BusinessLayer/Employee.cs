using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string Gender { get; set; }
        string City { get; set; }
    }
    public class Employee:IEmployee
    {

        public int EmployeeId { get; set; }
        //[Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }


    }
}
