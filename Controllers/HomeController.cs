
using Microsoft.AspNetCore.Mvc;

namespace CompleteExampleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => RedirectToAction("Index","Events");
    }
}
