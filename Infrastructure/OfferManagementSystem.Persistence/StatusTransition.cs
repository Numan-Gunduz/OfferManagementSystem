using System;
using System.Collections.Generic;

namespace OfferManagementSystem.Persistence;

public partial class StatusTransition
{
    public int Id { get; set; }

    public int? OfferId { get; set; }

    public int? OldStatusId { get; set; }

    public int? NewStatusId { get; set; }

    public DateTime? TransitionDate { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? UserId { get; set; }

    public virtual OfferStatus? NewStatus { get; set; }

    public virtual OfferMaster? Offer { get; set; }

    public virtual OfferStatus? OldStatus { get; set; }
}
