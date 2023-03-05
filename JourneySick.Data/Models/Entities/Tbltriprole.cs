using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;

public partial class Tbltriprole
{
    public int? FldRoleId { get; set; } = null!;

    public string? FldRoleName { get; set; }

    public string? FldType { get; set; }

    public string? FldDescription { get; set; }
}
