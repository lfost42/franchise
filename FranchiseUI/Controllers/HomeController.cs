using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FranchiseUI.Models;
using ParserLibrary;
using ParserLibrary.Databases;
using ParserLibrary.Models;
using ParserLibrary.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using CsvHelper;

namespace FranchiseUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ParserControl control = new ParserControl();
            return View(control);
        }

        [HttpPost]
        public IActionResult Index(ParserControl control, string csvFile)
        {
            if (ModelState.IsValid)
            {
                csvFile = "Files/TacoBell-US-AL.csv";
                List<LocationModel> locations = ParserControl.GetAllLocations(csvFile);
                control.GetFurthestLocations(locations);
            }
            return View(control);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
