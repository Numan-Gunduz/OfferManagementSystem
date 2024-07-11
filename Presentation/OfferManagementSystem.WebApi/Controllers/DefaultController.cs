using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferManagementSystem.WebApi.Models;
using System.Text;

namespace OfferManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet("[action]")] 
		public IActionResult TokenOlustur()
		{
			return Ok(new CreateToken().TokenCreate());
		}
		[HttpGet("[action]")]
		public IActionResult AdminTokenOlustur()
		{
			return Ok(new CreateToken().TokenCreateAdmin());
		}
		[HttpGet("[action]")]
		public IActionResult Test1()
		{
			return Ok("Hoşgeldiniz Bu Token oluştuğuna dair kanıt niteliğindedir");
		}
		[Authorize]
		[HttpGet("[action]")]
		public IActionResult Visitor()
		{
			return Ok("Hoşgeldiniz");
		}
		[Authorize(Roles = "Admin")]
		[HttpGet("[action]")]
		public IActionResult Admin()
		{
			return Ok("Admin Başarıyla Giriş Yaptı");
		}
		[Authorize(Roles = "UserManagmentt")]
		[HttpGet("[action]")]
		public IActionResult UserManagment()
		{
			return Ok("Kullanıcı Yöneticisi Başarıyla Giriş Yaptı");
		}
		[Authorize(Roles = "CustomerManagment")]
		[HttpGet("[action]")]
		public IActionResult CustomerManagment()
		{
			return Ok("Müşteri Yöneticisi Başarıyla Giriş Yaptı");
		}
		[Authorize(Roles = "OfferManagment")]
		[HttpGet("[action]")]
		public IActionResult OfferManagment()
		{
			return Ok("Teklif Yöneticisi Başarıyla Giriş Yaptı");
		}
	}

}
//https://localhost:44359/api/Default/TokenOlustur