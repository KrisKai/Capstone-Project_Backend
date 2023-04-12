using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;


public partial class Tbltripmember
{
    public int? FldMemberId { get; set; } = null!;

    public string? FldUserId { get; set; } = null!;

    public string? FldTripId { get; set; }

    public int? FldMemberRoleId { get; set; }

    public string? FldNickName { get; set; }

    public string? FldStatus { get; set; }

    public DateTime? FldCreateDate { get; set; }

    public string? FldCreateBy { get; set; }

    public DateTime? FldUpdateDate { get; set; }

    public string? FldUpdateBy { get; set; }
}
