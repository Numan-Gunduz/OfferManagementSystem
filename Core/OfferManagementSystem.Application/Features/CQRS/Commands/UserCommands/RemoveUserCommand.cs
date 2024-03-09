using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Commands.UserCommands
{
	public class RemoveUserCommand
	{
		public RemoveUserCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
