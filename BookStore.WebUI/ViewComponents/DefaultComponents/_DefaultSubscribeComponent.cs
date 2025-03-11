using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Text;

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
