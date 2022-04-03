using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParserLibrary;
using ParserLibrary.Data;
using ParserLibrary.Databases;

namespace FranchiseUI.Views.Locations
{
    public class IndexModel : PageModel
    {
        private static readonly IDatabaseData db;

        public static string csvFile { get; set; }

        public List<ITrackable> Records { get; set; } = new List<ITrackable>();

        public string fileName { get; set; }

        public void OnGet()
        {
            csvFile = "Files/TacoBell-US-AL.csv";
            fileName = csvFile.Substring(csvFile.IndexOf("/") + 1);
            Records = db.ReadAllRecords(csvFile);
        }

        public IActionResult OnPost()
        {
            return Page();
        }

    }
}