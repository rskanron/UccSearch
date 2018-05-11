using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UccSearch.Models;
using UccSearch.Services.COInfoMarket;

namespace UccSearch.Controllers
{
    public class DebtorsController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices] IMarketplaceService masterListService)
        {                         
            var searchTerm = HttpContext.Request.Query["searchTerm"].ToString();

            if (string.IsNullOrEmpty(searchTerm)) {
                return Json(new string[0]);
            } else {
                var data = masterListService.search("debtorname", searchTerm);
                return Json(data);
            }
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
