﻿using Franchise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Franchise.Data;
using Franchise.Data.Databases;
using Franchise.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Franchise.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILogger<LocationsController> _logger;

        public static string csvFile = "Files/TacoBell-US-AL.csv";
        public static IDictionary<int, LocationModel> globalDict = DictControl.CreateDict(csvFile);

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        //GET: LocationsController
        [HttpGet]
        public ActionResult Index()
        {

            if (ModelState.IsValid)
            {
                ViewData["dict"] = globalDict;
            }
            return View(globalDict);
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
        public IActionResult Create(LocationModel model)
        {
            //if (ModelState.IsValid)
            //{
               
            //}
            return RedirectToAction("Index");
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
        public ActionResult Edit(int id)
        {
            //if (ModelState.IsValid)
            //{

            //}
            return RedirectToAction("Index");
        }

        // GET: LocationsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
