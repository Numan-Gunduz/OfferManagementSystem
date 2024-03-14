using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferManagementSystem.Dto.UserDtos
{
    public class ResultUserDto
    {
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public DateTime? createdTime { get; set; }
        public DateTime? modifiedTime { get; set; }
        public int? createdUserId { get; set; }
    }

}

