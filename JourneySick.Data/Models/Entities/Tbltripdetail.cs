using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;

public partial class Tbltripdetail
{
    public string FldTripId { get; set; } = null!;

    public string? FldTripType { get; set; }

    public string? FldTripStartLocationName { get; set; }

    public string? FldTripStartLocationAddress { get; set; }

    public string? FldTripDestinationLocationName { get; set; }

    public string? FldTripDestinationLocationAddress { get; set; }

    public DateTime? FldCreateDate { get; set; }

    public string? FldCreateBy { get; set; }

    public DateTime? FldUpdateDate { get; set; }

    public string? FldUpdateBy { get; set; }
}
