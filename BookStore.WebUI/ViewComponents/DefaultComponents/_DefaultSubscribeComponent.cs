﻿using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultSubscribeComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
