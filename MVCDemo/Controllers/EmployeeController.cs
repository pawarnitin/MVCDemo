using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        //public ActionResult GetDetails()
        //{
        //    Employee employee = new Employee()
        //    {
        //        EmployeeId =101,
        //        Name = "Nitin",
        //        Gender = "Male",
        //        City = "Singapore"
        //    };

        //    return View( employee);
        //}
        public ActionResult GetDetails(int id)//Get Data from Database using entity framework
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);

            return View(employee);
        }
        //public ActionResult Index()// Single table data retrive method
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    List<Employee> employees= employeeContext.Employees.ToList();

        //    return View(employees);
        //}
        public ActionResult Index( int departmentId)// Multiple table data retrive
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId==departmentId).ToList();

            return View(employees);
        }
    }
}