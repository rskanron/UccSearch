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
            var appToken = "";
            //var secretToken = "";

            string searchTerm = HttpContext.Request.Query["searchTerm"].ToString();

            var client = new SodaClient("https://data.colorado.gov", appToken);

            // Get a reference to the resource itself
            // The result (a Resouce object) is a generic type
            // The type parameter represents the underlying rows of the resource
            // and can be any JSON-serializable class

            var dataset = client.GetResource<Dictionary<string, object>>(MASTER_LIST);
            var query = new SoqlQuery();
            query.Select("debtorname")
                .Where($"debtorname = '{searchTerm}'")
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

            var data = rows.ToList();

            return Json(data);
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
