﻿using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
