using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UccSearch.Models;
using UccSearch.Services.COInfoMarket;

namespace UccSearch.Controllers
{
    public class DebtorsController : Controller
    {
        [HttpGet("{searchTerm}")]
        public IActionResult Index([FromQuery] string searchTerm, [FromServices] IMarketplaceService masterListService)
        {                         
            var data = masterListService.search("debtorname", searchTerm);
            return Json(data);
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
