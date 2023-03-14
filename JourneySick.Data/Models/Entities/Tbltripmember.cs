using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;


public partial class Tbltripmember
{
    public string? FldUserId { get; set; } = null!;

    public string? FldTripId { get; set; }

    public string? FldMemberRoleId { get; set; }

    public string? FldNickName { get; set; }

    public string? FldStatus { get; set; }

    public string? FldEmail { get; set; }

    public string? FldPhone { get; set; }

    public string? FldAddress { get; set; }

    public DateTime? FldCreateDate { get; set; }

    public string? FldCreateBy { get; set; }

    public DateTime? FldUpdateDate { get; set; }

    public string? FldUpdateBy { get; set; }
}
