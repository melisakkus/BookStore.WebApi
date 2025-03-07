﻿using BookStore.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultPopulerBooksComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultPopulerBooksComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7158/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{				
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(categories);
			}
			return View();
		}
	}
}
