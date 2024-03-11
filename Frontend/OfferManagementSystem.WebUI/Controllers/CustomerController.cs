//using Microsoft.AspNetCore.Mvc;
//using OfferManagementSystem.WebUI.Dtos.CustomerDto;
//using System.Text;

//namespace OfferManagementSystem.WebUI.Controllers
//{
//	public class CustomerController : Controller
//	{
//		private readonly IHttpClientFactory _httpClientFactory;

//		public CustomerController(IHttpClientFactory httpClientFactory)
//		{
//			_httpClientFactory = httpClientFactory;
//		}

//		public async Task<IActionResult> Index()
//		{
//			var client = _httpClientFactory.CreateClient();
//			var responseMessage = await client.GetAsync("http://localhost:32265/api/Service");
//			if (responseMessage.IsSuccessStatusCode)
//			{
//				var jsonData = await responseMessage.Content.ReadAsStringAsync();
//				var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
//				return View(values);
//			}
//			return View();
//		}
//		public IActionResult AddService()
//		{
//			return View();
//		}
//		[HttpPost]
//		public async Task<IActionResult> AddService(CreateCustomerDto createserviceDto)
//		{
//			if (!ModelState.IsValid)
//			{
//				return View();
//			}
//			var client = _httpClientFactory.CreateClient();
//			var jsonData = JsonConvert.SerializeObject(createserviceDto);
//			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//			var responseMessage = await client.PostAsync("http://localhost:32265/api/Service", stringContent);
//			if (responseMessage.IsSuccessStatusCode)
//			{
//				return RedirectToAction("Index");

//			}
//			return View();
//		}
//		public async Task<IActionResult> DeleteService(int id)
//		{
//			var client = _httpClientFactory.CreateClient();
//			var responseMessage = await client.DeleteAsync($"http://localhost:32265/api/Service/{id}");
//			if (responseMessage.IsSuccessStatusCode)
//			{
//				return RedirectToAction("Index");
//			}
//			return View();
//		}
//		[HttpGet]
//		public async Task<IActionResult> UpdateService(int id)
//		{
//			var client = _httpClientFactory.CreateClient();
//			var responseMessage = await client.GetAsync($"http://localhost:32265/api/Service/{id}");

//			if (responseMessage.IsSuccessStatusCode)
//			{
//				var jsonData = await responseMessage.Content.ReadAsStringAsync();
//				var values = JsonConvert.DeserializeObject<UpdateCustomerDto>(jsonData);
//				return View(values);
//			}
//			return View();
//		}




//		[HttpPost]
//		public async Task<IActionResult> UpdateService(UpdateCustomerDto updateServiceDto)
//		{
//			if (!ModelState.IsValid)
//			{
//				return View();
//			}
//			var client = _httpClientFactory.CreateClient();
//			var jsonData = JsonConvert.SerializeObject(updateServiceDto);
//			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//			var responseMessage = await client.PutAsync("http://localhost:32265/api/Service/", stringContent);

//			if (responseMessage.IsSuccessStatusCode)
//			{
//				return RedirectToAction("Index");

//			}
//			return View();
//		}
//	}
//}
