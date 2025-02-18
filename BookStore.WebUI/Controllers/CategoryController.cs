using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> CategoryList()
        {
            return View();
        }
    }
}
