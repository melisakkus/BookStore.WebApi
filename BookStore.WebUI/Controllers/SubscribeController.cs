using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.UserEmailDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public SubscribeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEmail([FromBody] CreateUserEmailDto email)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(email);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7158/api/UserEmails", content);
            return Json(email);
        }

        public async Task<IActionResult> EmailList()
        {
            var client = _clientFactory.CreateClient();
            var values = await client.GetAsync("https://localhost:7158/api/UserEmails");
            if (values.IsSuccessStatusCode)
            {
                var result = await values.Content.ReadAsStringAsync();
                var emails = JsonConvert.DeserializeObject<List<ResultUserEmailDto>>(result);
                return View(emails);
            }
            return View();
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7158/api/UserEmails?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EmailList");
            }
            return View();
        }

        public IActionResult CreateSubscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateUserEmailDto model)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7158/api/UserEmails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EmailList");
            }
            return View();
        }

        public async Task<IActionResult> UpdateSubscribe(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/UserEmails/GetEmailById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var email = JsonConvert.DeserializeObject<UpdateUserEmailDto>(result);
                return View(email);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(UpdateUserEmailDto model)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7158/api/UserEmails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EmailList");
            }
            return View();
        }
    }
}

    

