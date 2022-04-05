using FranchiseUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ParserLibrary;
using ParserLibrary.Databases;
using ParserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseUI.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILogger<LocationsController> _logger;
        public LocationListModel localList = new LocationListModel();


        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        //GET: LocationsController
        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<ITrackable>());
        }


        [HttpPost]
        public ActionResult Index(List<ITrackable> view, string csvFile)
        {
            if (ModelState.IsValid)
            {
                csvFile = "Files/TacoBell-US-AL.csv";
                view = ParserControl.GetAllLocations(csvFile);
            }
            return View(view);
        }

        // GET: LocationsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ITrackable create)
        {
            if (ModelState.IsValid)
            {
                ParserControl.CreateLocation(create);
            }

            return View(create);
        }

        // GET: LocationsController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationsController/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ITrackable location)
        {

            return View(location);
        }

        // GET: LocationsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
