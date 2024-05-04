using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferManagementSystem.Application.Features.CQRS.Commands.OfferDetailCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.OfferDetailHandlers;
using OfferManagementSystem.Application.Features.CQRS.Queries.OfferDetailQueries;

namespace OfferManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfferDetailController : ControllerBase
	{

		private readonly CreateOfferDetailCommandHandler _createOfferDetailCommandHandler;
		private readonly GetOfferDetailByIdQueryHandler _getOfferDetailByIdQueryHandler;
		private readonly RemoveOfferDetailCommandHandler _removeOfferDetailCommandHandler;
		private readonly UpdateOfferDetailCommandHandler _updateOfferDetailCommandHandler;
		private readonly GetOfferDetailQueryHandler _getOfferDetailQueryCommandHandler;

		public OfferDetailController(CreateOfferDetailCommandHandler createOfferDetailCommandHandler, GetOfferDetailByIdQueryHandler getOfferDetailByIdQueryHandler, RemoveOfferDetailCommandHandler removeOfferDetailCommandHandler, UpdateOfferDetailCommandHandler updateOfferDetailCommandHandler, GetOfferDetailQueryHandler getOfferDetailQueryCommandHandler)
		{
			_createOfferDetailCommandHandler = createOfferDetailCommandHandler;
			_getOfferDetailByIdQueryHandler = getOfferDetailByIdQueryHandler;
			_removeOfferDetailCommandHandler = removeOfferDetailCommandHandler;
			_updateOfferDetailCommandHandler = updateOfferDetailCommandHandler;
			_getOfferDetailQueryCommandHandler = getOfferDetailQueryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> OfferDetailList()
		{
			var values = await _getOfferDetailQueryCommandHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOfferDetail(int id)
		{
			var values = await _getOfferDetailByIdQueryHandler.Handle(new GetOfferDetailByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOfferDetail(CreateOfferDetailCommand command)
		{
			await _createOfferDetailCommandHandler.Handle(command);
			return Ok("Teklif Detayları Bilgisi Eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOfferDetail(int id)
		{
			await _removeOfferDetailCommandHandler.Handle(new RemoveOfferDetailCommand(id));
			return Ok("Teklif Detayları Bilgisi Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOfferDetail(UpdateOfferDetailCommand command)
		{
			await _updateOfferDetailCommandHandler.Handle(command);
			return Ok("Teklif Detayları Bilgisi güncellendi");

		}
	}
}
