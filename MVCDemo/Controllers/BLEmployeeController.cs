using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCDemo.Controllers
{
    public class BLEmployeeController : Controller
    {
        // GET: BLEmployee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employee = employeeBusinessLayer.Employees.ToList();
            return View(employee);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {           
            return View();
        }

        ///// <summary>
        ///// This method invokes using formcollection object
        ///// </summary>
        ///// <param name="formCollection"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    Employee employee = new Employee();
        //    employee.Name = formCollection["Name"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.City = formCollection["City"];

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);
        //    return RedirectToAction("Index");

        //}


        /// <summary>
        /// this mothed invokes using model binder 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city)
        //{
        //    Employee employee = new Employee();
        //    employee.Name = name;
        //    employee.Gender = gender;
        //    employee.City = city;

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);
        //    return RedirectToAction("Index");

        //}

        //this way also possible to pass employee object to the emoloyee business layer.  
        //[HttpPost]
        //public ActionResult Create(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View("Create");

        //}

        //[HttpPost]
        //[ActionName("Create")]        
        //public ActionResult Create_Post()//update model
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = new Employee();
        //        UpdateModel(employee);
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View("Create");

        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()//update model throw exception if validation fails.
        //{
        //    Employee employee = new Employee();
        //    UpdateModel(employee);
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View("Create");

        //}


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()//Tryupdate model never throw the exception
        {
            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {               
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View("Create");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp =>emp.EmployeeId==id);
            return View(employee);
        }

        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)//IncludeProperties & Exclude Properties
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee = employeeBusinessLayer.Employees.Single(x => x.EmployeeId == id);
        //    UpdateModel(employee, new string[] { "Name","Gender","City"});//Inculde properties
        //    //UpdateModel(employee, null,null, new string[] { "Name"});//Exculde properties

        //    if (ModelState.IsValid)
        //    {                
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //[HttpPost]//Inculding & excluding properties from model binding using bind attribute
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Exclude ="Name")]Employee employee)//[Bind(Include = "EmployeeId,Gender,City")
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employee.Name = employeeBusinessLayer.Employees.Single(x => x.EmployeeId == employee.EmployeeId).Name;            
        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        [HttpPost]//Inculding & excluding properties from model binding using Interface
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)//[Bind(Include = "EmployeeId,Gender,City")
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
           Employee employee = employeeBusinessLayer.Employees.Single(x => x.EmployeeId == id);
            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
                employeeBusinessLayer.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}