using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FranchiseCalculatorUI.Models;
using ParserLibrary;
using ParserLibrary.Databases;
using ParserLibrary.Models;

namespace FranchiseCalculatorUI.Controllers
{
    public class HomeController : Controller
    {
        public ParserControl control = new ParserControl();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(control);
        }

        [HttpPost]
        public IActionResult Index(ParserControl control, string csvFile)
        {
            if (ModelState.IsValid)
            {
                csvFile = "Files/TacoBell-US-AL.csv";
                List<ITrackable> locations = control.ReadAllRecords(csvFile);
                control.GetFurthestLocations(locations);

                string fileName = csvFile.Substring(csvFile.IndexOf("/") + 1);
                control.solution.Message1 = $"Data file: {fileName}";
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
