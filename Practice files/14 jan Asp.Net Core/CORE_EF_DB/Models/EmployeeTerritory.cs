using System;
using System.Collections.Generic;

namespace CORE_EF_DB.Models;

public partial class EmployeeTerritory
{
    public int EmployeeId { get; set; }

    public string TerritoryId { get; set; } = null!;
}
