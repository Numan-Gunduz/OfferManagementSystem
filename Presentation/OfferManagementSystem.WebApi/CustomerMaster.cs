using System;
using System.Collections.Generic;

namespace OfferManagementSystem.WebApi;

public partial class CustomerMaster
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OfferMaster> OfferMasters { get; set; } = new List<OfferMaster>();

    public virtual UserMaster? User { get; set; }
}
