using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence.Context;

public partial class OfferMaster
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime ValidityDate { get; set; }

    public int? StatusId { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual CustomerMaster? Customer { get; set; }

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    public virtual OfferStatus? Status { get; set; }

    public virtual ICollection<StatusTransition> StatusTransitions { get; set; } = new List<StatusTransition>();

    public virtual UserMaster? User { get; set; }
    //public string? CustomerName { get; set; }
    //public string? UserName { get; set; }
    //public string? StatusName { get; set; }
    //public string? createdUserName { get; set; }
}
