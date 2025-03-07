using BookStore.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultBestSellingComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _DefaultBestSellingComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7158/api/Products/BestSellingBook");
			if(responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var bestSellingBook = JsonConvert.DeserializeObject<GetByIdProductDto>(json);
				return View(bestSellingBook);
			}
			return View();
		}
	}
}
