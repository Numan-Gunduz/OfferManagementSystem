using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Commands.OfferDetailCommands
{
	public class RemoveOfferDetailCommand
	{
        public int Id { get; set; }

		public RemoveOfferDetailCommand(int id)
		{
			Id = id;
		}
	}
}
