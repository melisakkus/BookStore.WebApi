using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStore.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private LanguageService _localization;
        private readonly IHttpClientFactory _clientFactory;
        public DashboardController(LanguageService localization, IHttpClientFactory clientFactory)
        {
            _localization = localization;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Abonelikler = _localization.Getkey("Abonelikler").Value;
            ViewBag.Alıntılar = _localization.Getkey("Alıntılar").Value;
            ViewBag.GenelBilgiler = _localization.Getkey("Genel Bilgiler").Value;
            ViewBag.İstatistikler = _localization.Getkey("İstatistikler").Value;
            ViewBag.Kategoriler = _localization.Getkey("Kategoriler").Value;
            ViewBag.Kitaplar = _localization.Getkey("Kitaplar").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            #region Statics

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7158/api/Dashboards/GetAuthors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(values);
                var last5product = products.TakeLast(5);
                var productsForAuhtor = products.TakeLast(8);
                ViewBag.productsForAuhtor = productsForAuhtor;
                ViewBag.ProductsLast5 = last5product;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetAvarageProductPrice");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var avgPrice = await responseMessage2.Content.ReadAsStringAsync();
                var price = Convert.ToDouble(avgPrice);
                ViewBag.avgPrice = price.ToString("F2");
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetCategoryCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var count = await responseMessage3.Content.ReadAsStringAsync();
                var categoryCount = Convert.ToInt32(count);
                ViewBag.categoryCount = categoryCount;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetProductCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var count = await responseMessage4.Content.ReadAsStringAsync();
                var productCount = Convert.ToInt32(count);
                ViewBag.productCount = productCount;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetEmailCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var count = await responseMessage5.Content.ReadAsStringAsync();
                var emailCount = Convert.ToInt32(count);
                ViewBag.emailCount = emailCount;
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetQuoteCount");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var count = await responseMessage6.Content.ReadAsStringAsync();
                var quoteCount = Convert.ToInt32(count);
                ViewBag.quoteCount = quoteCount;
            }

            var responseMessage7 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetCategoryWithLeastProduct");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var values = await responseMessage7.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<Category>(values);
                ViewBag.categoryWithLeastProduct = categories;
            }

            var responseMessage8 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetCategoryWithMostProduct");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var values = await responseMessage8.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<Category>(values);
                ViewBag.categoryWithMostProduct = categories;
            }

            var responseMessage9 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetLastProduct");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var value = await responseMessage9.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(value);
                ViewBag.lastProduct = product;
            }

            var responseMessage10 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetLastCategory");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var value = await responseMessage10.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<Category>(value);
                ViewBag.lastcategory = category;
            }

            var responseMessage11 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetLastQuote");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var value = await responseMessage11.Content.ReadAsStringAsync();
                var quote = JsonConvert.DeserializeObject<Quote>(value);
                ViewBag.lastquote = quote;
            }

            var responseMessage12 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetMostExpensiveProduct");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var value = await responseMessage12.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(value);
                ViewBag.expensiveBook = product;
            }

            var responseMessage13 = await client.GetAsync("https://localhost:7158/api/Dashboards/GetLeastStockProduct");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var value = await responseMessage13.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(value);
                ViewBag.leastStockProduct = product;
            }
            #endregion
            return View();

        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}

