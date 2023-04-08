using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;


public partial class Tbltrip
{
    public string FldTripId { get; set; } = null!;

    public string? FldTripName { get; set; }

    public decimal? FldTripBudget { get; set; }

    public string? FldTripDescription { get; set; }

    public DateTime FldEstimateStartTime { get; set; }

    public DateTime FldEstimateArrivalTime { get; set; }

    public string? FldTripStatus { get; set; }

    public int? FldTripMember { get; set; }

    public string FldTripPresenter { get; set; }
}
