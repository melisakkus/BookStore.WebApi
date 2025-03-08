using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.QuoteDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebUI.Controllers
{
    public class GeneralInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GeneralInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> InfoList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/GeneralInfo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GeneralInfo>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> TakeLastInfo()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/GeneralInfo/GetLastInfo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GeneralInfo>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInfo(GeneralInfo generalInfo)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(generalInfo);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7158/api/GeneralInfo", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("InfoList");
            }
            return View();
        }

        public async Task<IActionResult> UpdateInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/GeneralInfo/GetInfo?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GeneralInfo>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfo(GeneralInfo generalInfo)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(generalInfo);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7158/api/GeneralInfo", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("InfoList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7158/api/GeneralInfo?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("InfoList");
            }
            return View();

        }
    }
}
