using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.ProductHandlers;
using OfferManagementSystem.Application.Features.CQRS.Queries.ProductQueries;

namespace OfferManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly GetProductQueryHandler _getProductQueryHandler;
		private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
		private readonly CreateProductCommandHandler _createProductCommandHandler;
		private readonly UpdateProductCommandHandler _updateProductCommandHandler;
		private readonly RemoveProductCommandHandler _removeProductCommandHandler;

		public ProductController(GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler)
		{
			_getProductQueryHandler = getProductQueryHandler;
			_getProductByIdQueryHandler = getProductByIdQueryHandler;
			_createProductCommandHandler = createProductCommandHandler;
			_updateProductCommandHandler = updateProductCommandHandler;
			_removeProductCommandHandler = removeProductCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var values = await _getProductQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult>GetProduct(int id)
		{
			var values = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCommand command)
		{
			 await _createProductCommandHandler.Handle(command);
			return Ok("Ürün Bilgisi Eklendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveProduct(int id)
		{
			await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
			return Ok("Ürün Bilgisi Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
		{
			await _updateProductCommandHandler.Handle(command);
			return Ok("Ürün Bilgisi Güncellendi");
		}


	}
}
