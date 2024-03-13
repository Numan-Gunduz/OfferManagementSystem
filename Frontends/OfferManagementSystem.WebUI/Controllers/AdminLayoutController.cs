using Microsoft.AspNetCore.Mvc;

namespace OfferManagementSystem.WebUI.Controllers
{
	public class AdminLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	
	}
}
