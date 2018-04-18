using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SODA;
using UccSearch.Models;

namespace UccSearch.Controllers
{
    public class HomeController : Controller
    {

        const string MASTER_LIST = "h28s-f3n9";

        const string FILINGS = "8d38-bpb6";

        public IActionResult Index()
        {


            var appToken = "H1vAoB9qxzcZPIlRgqGW5U791";
            var secretToken = "LJ480joYQ1IDuygZch1zv3mQRxwhVsLtPDY9";



            


            var client = new SodaClient("https://data.colorado.gov", appToken);

            // Get a reference to the resource itself
            // The result (a Resouce object) is a generic type
            // The type parameter represents the underlying rows of the resource
            // and can be any JSON-serializable class

            var dataset = client.GetResource<Dictionary<string, object>>(MASTER_LIST);
            var query = new SoqlQuery();
            query.Select("debtorname")
                .Where("debtorname = 'SEEDS RANCH INC'")
                .Limit(10);
            var rows = dataset.Query(query);
            //System.Console.WriteLine(query.LimitValue);            

            // Resource objects read their own data
            //var dataset = client.GetResource<Dictionary<string, object>>(FILINGS);
            //var rows = dataset.GetRows(limit: 10);

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
