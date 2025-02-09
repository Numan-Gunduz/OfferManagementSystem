﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Application.Features.CQRS.Commands.ProductCommands
{
	public class CreateProductCommand
	{


		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public decimal Price { get; set; }

		public DateTime? CreatedTime { get; set; }

		public DateTime? ModifiedTime { get; set; }

		public int? UserId { get; set; }
	}
}
