using System;
using System.Collections.Generic;

namespace JourneySick.Data.Models.Entities
{
    public partial class Efmigrationshistory
    {
        public string MigrationId { get; set; } = null!;
        public string ProductVersion { get; set; } = null!;
    }
}
