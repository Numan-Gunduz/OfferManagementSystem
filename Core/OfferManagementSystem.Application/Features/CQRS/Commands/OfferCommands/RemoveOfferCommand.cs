using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Commands.OfferCommands
{
	public class RemoveOfferCommand
	{
		public RemoveOfferCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
