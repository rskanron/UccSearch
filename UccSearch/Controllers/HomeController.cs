using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UccSearch.Models;
using UccSearch.Services.COInfoMarket;

namespace UccSearch.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(UccService uCCSearchService)
        {                         
            var searchTerm = HttpContext.Request.Query["searchTerm"].ToString();

            if (string.IsNullOrEmpty(searchTerm)) {
                return Json(new string[0]);
            } else {
                var data = uCCSearchService.UCCSearch(searchTerm);
                return Json(data);
            }
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
