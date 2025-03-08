using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UILayoutFooterComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
