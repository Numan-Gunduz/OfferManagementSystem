using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferManagementSystem.Application.Features.CQRS.Commands.CustomerCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.CustomerHandlers;
using OfferManagementSystem.Application.Features.CQRS.Queries.CustomerQueries;

namespace OfferManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{

		private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
		private readonly GetCustomerByIdQueryHandler _getCustomerByIdQueryHandler;
		private readonly RemoveCustomerCommandHandler _removeCustomerCommandHandler;
		private readonly UpdateCustomerCommandHandler _updateCustomerCommandHandler;
		private readonly GetCustomerQueryHandler _getCustomerQueryCommandHandler;

		public CustomerController(CreateCustomerCommandHandler createCustomerCommandHandler, GetCustomerByIdQueryHandler getCustomerByIdQueryHandler, RemoveCustomerCommandHandler removeCustomerCommandHandler, UpdateCustomerCommandHandler updateCustomerCommandHandler, GetCustomerQueryHandler getCustomerQueryCommandHandler)
		{
			_createCustomerCommandHandler = createCustomerCommandHandler;
			_getCustomerByIdQueryHandler = getCustomerByIdQueryHandler;
			_removeCustomerCommandHandler = removeCustomerCommandHandler;
			_updateCustomerCommandHandler = updateCustomerCommandHandler;
			_getCustomerQueryCommandHandler = getCustomerQueryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> CustomerList()
		{
			var values = await _getCustomerQueryCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCustomer(int id)
		{
			var values = await _getCustomerByIdQueryHandler.Handle(new GetCustomerByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
		{
			await _createCustomerCommandHandler.Handle(command);
			return Ok("Müşteri Bilgisi Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> RemoveCustomer(int id)
		{
			await _removeCustomerCommandHandler.Handle(new RemoveCustomerCommand(id));
			return Ok("Müşteri Bilgisi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCustomer(UpdateCustomerCommand command)
		{
			await _updateCustomerCommandHandler.Handle(command);
			return Ok("Müşteri Bilgisi güncellendi");

		}
	}
}
