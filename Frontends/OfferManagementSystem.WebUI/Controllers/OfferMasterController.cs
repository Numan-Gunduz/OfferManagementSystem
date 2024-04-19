using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfferManagementSystem.Dto.OfferMasterDtos;
using System.Text;

namespace OfferManagementSystem.WebUI.Controllers
{
    public class OfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44359/api/Offer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        public IActionResult AddOffer()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> AddOffer(AddOfferDto addOfferDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(addOfferDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:44359/api/Offer", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");

        //    }
        //    return View();
        //}
        public async Task<IActionResult> RemoveOffer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44359/api/Offer/{id}");
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

        //[HttpGet]
        //public async Task<IActionResult> UpdateOffer(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"https://localhost:44359/api/Offer/{id}");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateOfferDtos>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}




        //[HttpPost]
        //public async Task<IActionResult> UpdateOffer(UpdateOfferDtos updateOfferDtos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateOfferDtos);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:44359/api/Offer", stringContent);

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");

        //    }
        //    return View();
        //}
    }
}
