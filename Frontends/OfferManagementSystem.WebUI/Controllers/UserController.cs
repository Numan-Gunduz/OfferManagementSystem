using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfferManagementSystem.Dto.UserDtos;
using System.Text;

namespace OfferManagementSystem.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44359/api/UserMaster");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }
		[HttpGet]
		public IActionResult AddUser()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddUser(AddUserDto createserviceDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createserviceDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44359/api/UserMaster", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
		public async Task<IActionResult>RemoveUser(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44359/api/UserMaster/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			else
			{
				// Başarısız bir silme işlemi olduğunda, aynı sayfayı tekrar göstermek için Index'e yeniden yönlendirme yapıyoruz
				return RedirectToAction("Index");
			}
		}


		[HttpGet]
		public async Task<IActionResult> UpdateUser(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44359/api/UserMaster/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateUserDto>(jsonData);
				return View(values);
			}
			return View();
		}




		[HttpPost]
		public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateUserDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44359/api/UserMaster", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
	}
}
