using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly IConfiguration configuration;

	public AuthenticationController(IConfiguration configuration)
	{
		this.configuration = configuration;
	}

	[HttpGet("[action]")]
	public ActionResult SignIn([FromHeader] string username, [FromHeader] string password)
	{
		if (username.Equals("admin") && password.Equals("1234"))
		{
			var expire = configuration["WebApiToken:AccessTokenExpire"];
			SecurityKey accessTokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["WebApiToken:AccessTokenKey"]));

			var accessClaims = new List<Claim>
			{
				new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.UniqueName,username)
			};

			var accessTokenCredential = new SigningCredentials(accessTokenKey,SecurityAlgorithms.HmacSha256);

			var accessToken = new JwtSecurityToken(
				issuer: configuration["WebApiToken:Issuer"],
				audience: configuration["WebApiToken:Audience"],
				claims: accessClaims,
				signingCredentials: accessTokenCredential,
				notBefore:DateTime.UtcNow,
				expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(expire))
				);

			return Ok(new JwtSecurityTokenHandler().WriteToken(accessToken));
		}

		return BadRequest();
	}
}
