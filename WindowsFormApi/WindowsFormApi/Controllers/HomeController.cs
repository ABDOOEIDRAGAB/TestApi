﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WindowsFormApi.Models;

namespace WindowsFormApi.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllApiMethod()
        {
            return View();
        }

    }
}