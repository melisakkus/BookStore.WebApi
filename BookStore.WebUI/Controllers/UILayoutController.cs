using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
