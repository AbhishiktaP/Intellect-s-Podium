﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntellectsPodium2.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Forum()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
    }
}