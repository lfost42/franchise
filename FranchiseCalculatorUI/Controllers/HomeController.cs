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

namespace FranchiseCalculatorUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ParserControl control = new ParserControl();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ParserControl control, string csvFile)
        {
            csvFile = "Files/TacoBell-US-AL.csv";
            List<ITrackable> locations = control.ReadAllRecords(csvFile);
            control.GetFurthestLocations(locations);
            return View(control);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
