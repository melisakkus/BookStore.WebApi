using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultLittlePicturesComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
