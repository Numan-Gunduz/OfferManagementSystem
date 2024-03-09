using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferManagementSystem.Application.Features.CQRS.Commands.UserCommands;
using OfferManagementSystem.Application.Features.CQRS.Handlers.UserHandlers;
using OfferManagementSystem.Application.Features.CQRS.Queries.UserQueries;

namespace OfferManagementSystem.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserMasterController : ControllerBase
	{
		private readonly CreateUserCommandHandler _createUserCommandHandler;
		private readonly GetUserByIdQueryHandler _getUserByIdQueryHandler;
		private readonly RemoveUserCommandHandler _removeUserCommandHandler;
		private readonly UpdateUserCommandHandler _updateUserCommandHandler;
		private readonly GetUserQueryHandler _getUserQueryCommandHandler;

		public UserMasterController(CreateUserCommandHandler createUserCommandHandler, GetUserByIdQueryHandler getUserByIdQueryHandler, RemoveUserCommandHandler removeUserCommandHandler, UpdateUserCommandHandler updateUserCommandHandler, GetUserQueryHandler getUserQueryCommandHandler)
		{
			_createUserCommandHandler = createUserCommandHandler;
			_getUserByIdQueryHandler = getUserByIdQueryHandler;
			_removeUserCommandHandler = removeUserCommandHandler;
			_updateUserCommandHandler = updateUserCommandHandler;
			_getUserQueryCommandHandler = getUserQueryCommandHandler;
		}
		[HttpGet]
		public async Task<IActionResult> UserList()
		{
			var values =  await _getUserQueryCommandHandler.Handle();
			return Ok (values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult>GetUser(int id)
		{
			var values = await _getUserByIdQueryHandler.Handle(new GetUserByIdQuery(id));
			return Ok (values);
		}
		[HttpPost]
		public async Task<IActionResult>CreateUser(CreateUserCommand command)
		{
			await _createUserCommandHandler.Handle(command);
			return Ok("Kullanıcı Bilgisi Eklendi");
		}
		[HttpDelete]
		public async Task <IActionResult>RemoveUser( int id)
		{
			await _removeUserCommandHandler.Handle(new RemoveUserCommand(id));
			return Ok("Kullanıcı Bilgisi Silindi");
		}
		[HttpPut]
		public async Task <IActionResult>UpdateUser(UpdateUserCommand command)
		{
			await _updateUserCommandHandler.Handle(command);
			return Ok("Kullanıcı Bilgisi güncellendi");

		}
	}
}
