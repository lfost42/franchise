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
        public List<LocationModel> mainLoc = new List<LocationModel>();
        public DictModel mainDict = new DictModel();

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        //GET: LocationsController
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<ITrackable> locations = new List<LocationModel>();

            if (ModelState.IsValid)
            {
                var csvFile = "Files/TacoBell-US-AL.csv";
                var dict = DictControl.dictControl.DictRecords(csvFile);
                locations = DictControl.dictControl.DictToModels(dict);
            }
            return View(locations);
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
        public IActionResult Create(DictModel dict, LocationModel location)
        {
            LocationModel loc = new LocationModel();
            if (ModelState.IsValid)
            {
                dict = DictControl.dictControl.AddLocation(dict, location);
                mainLoc = DictControl.dictControl.DictToModels(dict);
            }

            return View(mainLoc);
        }

        // GET: LocationsController/Details/5
        [HttpGet]
        public ActionResult Details(DictModel dict, int id)
        {
            if (ModelState.IsValid)
            {
                DictControl.dictControl.ViewLocation(dict, id);
            }
            return RedirectToAction("Index");
        }

        // GET: LocationsController/Edit/5
        [HttpGet]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DictModel dict, int id, LocationModel model)
        {
            DictModel tempDict = new DictModel();
            if (ModelState.IsValid)
            {
                DictControl.dictControl.EditLocation(dict, id, model);
            }
            return RedirectToAction("Index");
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
        public ActionResult Delete(DictModel dict, int id)
        {
            if (ModelState.IsValid)
            {
                DictControl.dictControl.DeleteLocation(dict, id);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
