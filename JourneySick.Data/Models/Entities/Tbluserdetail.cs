using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;

public partial class Tbluserdetail
{
    public string FldUserId { get; set; } = null!;

    public string? FldRole { get; set; }

    public DateTime? FldBirthday { get; set; }

    public string? FldActiveStatus { get; set; }

    public string? FldEmail { get; set; }

    public string? FldFullname { get; set; }

    public string? FldPhone { get; set; }

    public string? FldAddress { get; set; }

    public float? FldExperience { get; set; }

    public int? FldTripCreated { get; set; }

    public int? FldTripJoined { get; set; }

    public int? FldTripCompleted { get; set; }

    public int? FldTripCancelled { get; set; }

    public DateTime? FldCreateDate { get; set; }

    public string? FldCreateBy { get; set; }

    public DateTime? FldUpdateDate { get; set; }

    public string? FldUpdateBy { get; set; }
}
