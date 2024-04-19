﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Commands.UserCommands
{
	public class UpdateUserCommand
	{
		public int Id { get; set; }

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public DateTime? CreatedTime { get; set; }

		public DateTime? ModifiedTime { get; set; }

	//	public int? CreatedUserId { get; set; }
	}
}
