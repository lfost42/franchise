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
            ViewBag.image = "/images/app.png";
            ViewBag.Descption = "Evaluates the coverage health of a franchise " +
                "by determining which locations (in a provided csv file) are " +
                "farthest apart. Suggests areas that may need expansion or more " +
                "coverage.";
            ParserControl control = new ParserControl();
            return View(control);
        }

        [HttpPost]
        public IActionResult Index(ParserControl control, string csvFile)
        {
            if (ModelState.IsValid)
            {
                csvFile = "Files/TacoBell-US-AL.csv";
                List<ITrackable> locations = ParserControl.GetAllLocations(csvFile);
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
