//using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OfferManagementSystem.WebApi.Models
{
	public class CreateToken
	{
		public string TokenCreate()
		{
			var bytes = Encoding.UTF8.GetBytes("OfferManagmentSytemOfferManagmentSytem");

			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

			SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost/",
				notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials);

			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			return jwtSecurityTokenHandler.WriteToken(token);
		}
		public string TokenCreateAdmin()
		{
			var bytes = Encoding.UTF8.GetBytes("OfferManagmentSytemOfferManagmentSytem");
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
			SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			List<Claim> claims = new List<Claim>()
			{
				 new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Role, "Admin"),
				new Claim(ClaimTypes.Role, "CustomerManagment"),
				new Claim(ClaimTypes.Role, "OfferManagment"),	
				new Claim(ClaimTypes.Role, "UserManagment")
			};
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "https://localhost", audience: "https://localhost/",
				notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials, claims: claims);
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(jwtSecurityToken);

		}
	}
}
