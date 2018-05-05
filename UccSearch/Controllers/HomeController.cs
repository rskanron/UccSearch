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

        const string MASTER_LIST_ID = "h28s-f3n9";

        const string FILINGS_ID = "8d38-bpb6";

        const string BASE_URL = "https://data.colorado.gov";

        public IActionResult Index()
        {                         
            var appToken = "";

            var searchTerm = HttpContext.Request.Query["searchTerm"].ToString();

            if (string.IsNullOrEmpty(searchTerm)) {
                return Json(new string[0]);
            } else {

                var client = new SodaClient(BASE_URL, appToken);

                var dataset = client.GetResource<Dictionary<string, object>>(MASTER_LIST_ID);

                var query = new SoqlQuery();
                query.Select("debtorname")
                    .Where($"debtorname like '%{searchTerm.ToUpper()}%'")
                    .Limit(30);

                var rows = dataset.Query(query);

                var data = rows.ToList();

                return Json(data);
            }
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
