using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.AdminComponents
{
    public class _AdminComponentsBreadCrumbs : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
