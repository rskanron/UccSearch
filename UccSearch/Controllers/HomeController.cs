using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SODA;
using UccSearch.Models;

namespace UccSearch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {


            var appToken = "H1vAoB9qxzcZPIlRgqGW5U791";
            var secretToken = "LJ480joYQ1IDuygZch1zv3mQRxwhVsLtPDY9";


            var client = new SodaClient("https://data.colorado.gov", appToken);

            // Get a reference to the resource itself
            // The result (a Resouce object) is a generic type
            // The type parameter represents the underlying rows of the resource
            // and can be any JSON-serializable class
            var dataset = client.GetResource<Dictionary<string, object>>("h28s-f3n9");

            // Resource objects read their own data
            var rows = dataset.GetRows(limit: 10);

            //Console.WriteLine("Got {0} results. Dumping first results:", rows.Count());

            //foreach (var keyValue in rows.First())
            //{
            //    Console.WriteLine(keyValue);
            //}

            ViewBag.data = rows.ToList();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
