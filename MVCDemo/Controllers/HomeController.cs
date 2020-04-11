﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        //{
        //    return typeof(Controller).Assembly.GetName().Version.ToString();//Return the version of MVC application
        //}
        //public ActionResult Index()//ViewBag
        //{
        //    ViewBag.Countries = new List<string>()
        //    {
        //        "India",
        //        "USA",
        //        "UK",
        //        "Canada"
        //    };
        //    return View();

        //}
        public ActionResult Index()
        {
            ViewData["Countries"]= new List<string>()
            {
                "India",
                "USA",
                "UK",
                "Canada"
            };
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}