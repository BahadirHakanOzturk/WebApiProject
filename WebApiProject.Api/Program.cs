using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiProject.Api.Middlewares;
using WebApiProject.Application;
using WebApiProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(
	options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(
		options =>
		{
			var clockSkew = builder.Configuration["WebApiToken:ClockSkew"];

			var issuers = new List<string>
			{
				builder.Configuration["WebApiToken:Issuer"]
			};

			var audiences = new List<string>
			{
				builder.Configuration["WebApiToken:Audience"]
			};

			SecurityKey accessTokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["WebApiToken:AccessTokenKey"]));

			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuers = issuers,

				ValidateAudience = true,
				ValidAudiences = audiences,

				ValidateIssuerSigningKey = true,
				IssuerSigningKeys = new List<SecurityKey> { accessTokenKey },

				ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(clockSkew))
			};
		});

builder.Services.AddApplicationService();
builder.Services.AddPersistenceService(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandleMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
