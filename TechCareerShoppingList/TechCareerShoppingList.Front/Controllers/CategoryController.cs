using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using TechCareerShoppingList.Front.Models;
using Microsoft.AspNetCore.Authorization;

namespace TechCareerShoppingList.Front.Controllers
{

    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Create(CategoryCreateResponseModel model)
        {
            if (ModelState.IsValid)
            {

                var client = HttpClientCreate();
                var requestContext = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:24296/api/Categories", requestContext);

                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }

        }
        public async Task<IActionResult> List()
        {
            var client = this.HttpClientCreate();
            var response = await client.GetAsync("http://localhost:24296/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var listCategory = JsonSerializer.Deserialize<List<CategoryListResponseModel>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                return View(listCategory);
            }
            /*
             * else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden) //cookini kaybettim/
                return RedirectToAction("AccessDenied", "Account");}
            */
            else
            {
                return View("Index", "Home");

            }

        }
        public async Task<IActionResult> Update(CategoryUpdateResponseModel model)
        {
            if (ModelState.IsValid)
            {

                var client = HttpClientCreate();
                var requestContext = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:24296/api/Categories", requestContext);

                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            await this.HttpClientCreate().DeleteAsync($"http://localhost:24296/api/Categories/{id}");
            return RedirectToAction("List");

        }

        private HttpClient HttpClientCreate()
        {
            var client = _httpClientFactory.CreateClient();
            var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return client;
        }
    }
}
