using OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers;
using OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers;
using OfferManagementSystem.Application.Interfaces;
using OfferManagementSystem.Persistence;
using OfferManagementSystem.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
