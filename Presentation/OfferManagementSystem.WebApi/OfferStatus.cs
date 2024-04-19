using System;
using System.Collections.Generic;

namespace OfferManagementSystem.WebApi;

public partial class OfferStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? ModifiedTime { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OfferMaster> OfferMasters { get; set; } = new List<OfferMaster>();

    public virtual ICollection<StatusTransition> StatusTransitionNewStatuses { get; set; } = new List<StatusTransition>();

    public virtual ICollection<StatusTransition> StatusTransitionOldStatuses { get; set; } = new List<StatusTransition>();
}
