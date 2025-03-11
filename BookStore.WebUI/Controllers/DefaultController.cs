using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.UserEmailDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text;
using BookStore.WebUI.Dtos.UserEmailDtos;
using BookStore.BusinessLayer.Abstract;


namespace BookStore.WebUI.Controllers
{
	public class DefaultController : Controller
	{       
        public IActionResult Index()
        {
            return View();
        }
    }
}
