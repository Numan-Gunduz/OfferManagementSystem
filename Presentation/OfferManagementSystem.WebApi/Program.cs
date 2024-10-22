using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers;
using OfferManagementSystem.Application.Features.CQRS.Handlers.OfferDetailHandlers;
using OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers;
using OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers;
using OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence.Context;
using OfferManagementSystem.Persistence.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.RequireHttpsMetadata = false;
	opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidIssuer =   "https://localhost",
		ValidAudience = "https://localhost",

		ClockSkew = TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OfferManagmentSytemOfferManagmentSytem")),
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,

	};
});
		


builder.Services.AddScoped<OfferManagementSystemContext>();
//builder.Services.AddScoped(typeof(IRepository<>),typeof(IRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add services to the container.
builder.Services.AddScoped < GetUserQueryHandler>();
builder.Services.AddScoped < GetUserByIdQueryHandler>();
builder.Services.AddScoped < CreateUserCommandHandler>();
builder.Services.AddScoped < RemoveUserCommandHandler>();
builder.Services.AddScoped < UpdateUserCommandHandler>();


builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<RemoveProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();





builder.Services.AddScoped<GetCustomerQueryHandler>();
builder.Services.AddScoped<GetCustomerByIdQueryHandler>();
builder.Services.AddScoped<CreateCustomerCommandHandler>();
builder.Services.AddScoped<RemoveCustomerCommandHandler>();
builder.Services.AddScoped<UpdateCustomerCommandHandler>();


builder.Services.AddScoped<GetOfferQueryHandler>();
builder.Services.AddScoped<GetOfferByIdQueryHandler>();
builder.Services.AddScoped<CreateOfferCommandHandler>();
builder.Services.AddScoped<RemoveOfferCommandHandler>();
builder.Services.AddScoped<UpdateOfferCommandHandler>();



builder.Services.AddScoped<GetOfferDetailQueryHandler>();
builder.Services.AddScoped<GetOfferDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOfferDetailCommandHandler>();
builder.Services.AddScoped<RemoveOfferDetailCommandHandler>();
builder.Services.AddScoped<UpdateOfferDetailCommandHandler>();




builder.Services.AddCors(opt =>
{
	opt.AddPolicy("OfferApiCors", opts =>
	{
		opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("OfferApiCors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
