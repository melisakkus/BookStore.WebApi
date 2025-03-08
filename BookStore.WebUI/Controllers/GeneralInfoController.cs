using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.GenerallInfoDtos;
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

        public async Task<IActionResult> GeneralInfoList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/GeneralInfo");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var generalInfo = JsonConvert.DeserializeObject<List<ResultGeneralInfoDto>>(content);
                return View(generalInfo);
            }
            return View();
        }

        public async Task<IActionResult> DeleteGeneralInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7158/api/GeneralInfo?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GeneralInfoList");
            }
            return View();
        }

        public async Task<IActionResult> CreateGeneralInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeneralInfo(CreateGeneralInfoDto createGeneralInfoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createGeneralInfoDto);
            var value = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7158/api/GeneralInfo", value);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GeneralInfoList");
            }
            return View();
        }

        public async Task<IActionResult> UpdateGeneralInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/GeneralInfo/GetInfo?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateGeneralInfoDto>(data);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGeneralInfo(UpdateGeneralInfoDto updateGeneralInfoDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateGeneralInfoDto);
            var value = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7158/api/GeneralInfo", value);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GeneralInfoList");
            }
            return View();
        }
    }
}
