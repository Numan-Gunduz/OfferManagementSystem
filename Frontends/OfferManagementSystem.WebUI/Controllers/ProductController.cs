using Microsoft.AspNetCore.Mvc;

namespace OfferManagementSystem.WebUI.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
