using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Franchise.Models;
using Parser.Data;
using Parser.Data.Databases;
using Parser.Data.Models;
using Parser.Data.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using CsvHelper;

namespace Franchise.Controllers
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
