﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var now = DateTime.Now;
            var model = new Index2Model() { Message = $"Data do servidor é: {now.ToShortDateString()}" };
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new Index2Model() { Message = $"Termos de privacidade" };
            return View(model);
        }

        public IActionResult HelloWorld()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
