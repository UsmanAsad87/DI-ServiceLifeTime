using DI_ServiceLifeTime.Models;
using DI_ServiceLifeTime.Sevices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_ServiceLifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopedGuidService _scoped1;
        private readonly IScopedGuidService _scoped2;

        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;

        private readonly ISingletonGuidServices _singleton1;
        private readonly ISingletonGuidServices _singleton2;


        public HomeController(ISingletonGuidServices singletonGuid1, ISingletonGuidServices singletonGuid2, IScopedGuidService scopedGuid1, IScopedGuidService scopedGuid2, ITransientGuidService transientGuid1, ITransientGuidService transientGuid2)
        {
            _scoped1 = scopedGuid1;
            _scoped2 = scopedGuid2; 
            _transient1 = transientGuid1;
            _transient2 = transientGuid2;
            _singleton1 = singletonGuid1;
            _singleton2 = singletonGuid2;
        }

        public IActionResult Index()
        {
            StringBuilder mesages = new StringBuilder();
            mesages.Append($"Transient 1 : {_transient1.GetGuid()}\n");
            mesages.Append($"Transient 2 : {_transient2.GetGuid()}\n\n\n");

            mesages.Append($"Scoped 1 : {_scoped1.GetGuid()}\n");
            mesages.Append($"Scoped 2 : {_scoped2.GetGuid()}\n\n\n");

            mesages.Append($"Singleton 1 : {_singleton1.GetGuid()}\n");
            mesages.Append($"Singleton 2 : {_singleton2.GetGuid()}\n\n\n");

            return Ok(mesages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
