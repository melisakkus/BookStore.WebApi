using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultFeatureComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultFeatureComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/Products/LastFourBooks");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(data);
			}
            return View();
        }
    }
}
