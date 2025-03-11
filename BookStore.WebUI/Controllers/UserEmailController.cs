using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class UserEmailController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserEmailController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> EmailList()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/UserEmails");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var emails = JsonConvert.DeserializeObject<List<UserEmail>>(values);
                return View(emails);
            }
            return View();
        }

        public IActionResult CreateEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmail(UserEmail email)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(email);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7158/api/UserEmails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EmailList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmail(int id)
        {
            var client = _clientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7158/api/UserEmails?id=" + id);
            return RedirectToAction("EmailList");
        }

        public async Task<IActionResult> UpdateEmail(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/UserEmails/GetEmailById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var email = JsonConvert.DeserializeObject<UserEmail>(jsonData);
                return View(email);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmail(UserEmail email)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(email);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7158/api/UserEmails", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EmailList");
            }
            return View();
        }

    }
}
