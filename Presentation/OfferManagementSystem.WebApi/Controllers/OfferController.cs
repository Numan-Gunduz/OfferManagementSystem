using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.OfferHandlers;
using OfferManagementSystem.Application.Features.CQRS.Queries.OfferQueries;

namespace OfferManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfferController : ControllerBase
	{

		private readonly GetOfferQueryHandler _getOfferQueryHandler;
		private readonly GetOfferByIdQueryHandler _getOfferByIdQueryHandler;
		private readonly CreateOfferCommandHandler _createOfferCommandHandler;
		private readonly UpdateOfferCommandHandler _updateOfferCommandHandler;
		private readonly RemoveOfferCommandHandler _removeOfferCommandHandler;

		public OfferController(GetOfferQueryHandler getOfferQueryHandler, GetOfferByIdQueryHandler getOfferByIdQueryHandler, CreateOfferCommandHandler createOfferCommandHandler, UpdateOfferCommandHandler updateOfferCommandHandler, RemoveOfferCommandHandler removeOfferCommandHandler)
		{
			_getOfferQueryHandler = getOfferQueryHandler;
			_getOfferByIdQueryHandler = getOfferByIdQueryHandler;
			_createOfferCommandHandler = createOfferCommandHandler;
			_updateOfferCommandHandler = updateOfferCommandHandler;
			_removeOfferCommandHandler = removeOfferCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> OfferList()
		{
			var values = await _getOfferQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOffer(int id)
		{
			var values = await _getOfferByIdQueryHandler.Handle(new GetOfferByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateOffer(CreateOfferCommand command)
		{
			await _createOfferCommandHandler.Handle(command);
			return Ok("Teklif Bilgisi Eklendi");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveOffer(int id)
		{
			await _removeOfferCommandHandler.Handle(new RemoveOfferCommand(id));
			return Ok("Teklif Bilgisi Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOffer(UpdateOfferCommand command)
		{
			await _updateOfferCommandHandler.Handle(command);
			return Ok("Teklif Bilgisi Güncellendi");
		}

	}
}
