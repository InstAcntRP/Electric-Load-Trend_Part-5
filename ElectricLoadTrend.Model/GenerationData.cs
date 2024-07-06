using System;
using System.Collections.Generic;

namespace ElectricLoadTrend.Model;

public partial class GenerationData
{
    public int DataId { get; set; }

    public DateTime Dt { get; set; }

    public double GeneratedMw { get; set; }

    public bool Actual { get; set; }
}
