﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Dto.CustomerDtos
{
	public class ResultCustomerDto
	{

		public int Id { get; set; }

		public string? FirstName { get; set; } = null!;

		public string? LastName { get; set; } = null!;

		public string? Email { get; set; } = null!;

		public string? Phone { get; set; } = null!;

		public string? Address { get; set; } = null!;

		public DateTime? CreatedTime { get; set; }

		public DateTime? ModifiedTime { get; set; }

		public int? UserId { get; set; }
        public string? UserName { get; set; }

    }
}
