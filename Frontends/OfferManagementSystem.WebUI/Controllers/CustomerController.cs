using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfferManagementSystem.Dto.CustomerDtos;
using OfferManagementSystem.Dto.ProductDtos;
using System.Text;

namespace OfferManagementSystem.WebUI.Controllers
{
	public class CustomerController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CustomerController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44359/api/Customer");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
				return View(values);
			}
			return View();
		}


		public IActionResult AddCustomer()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddCustomer(AddCustomerDto addCustomerDto)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(addCustomerDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44359/api/Customer", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
		public async Task<IActionResult> RemoveCustomer(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44359/api/Customer/{id}");
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
		public async Task<IActionResult> UpdateCustomer(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44359/api/Customer/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCustomerDtos>(jsonData);
				return View(values);
			}
			return View();
		}




		[HttpPost]
		public async Task<IActionResult> UpdateCustomer(UpdateCustomerDtos updateCustomerDtos)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCustomerDtos);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44359/api/Customer", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return View();
		}
	}
}
