using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities;

public partial class Tbluser
{
    public string FldUserId { get; set; } = null!;

    public string FldUsername { get; set; } = null!;

    public string FldPassword { get; set; } = null!;
}
