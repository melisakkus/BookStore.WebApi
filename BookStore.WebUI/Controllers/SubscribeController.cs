using BookStore.WebUI.Dtos.UserEmailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    }
}
