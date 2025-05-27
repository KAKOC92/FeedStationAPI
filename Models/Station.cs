using System;
using System.Collections.Generic;

namespace FDAPI.Models;

public partial class Station
{
    public short Stid { get; set; }

    public string Kid { get; set; } = null!;

    public string? Kod { get; set; }

    public string? Stn { get; set; }

    public string? Locat { get; set; }

    public short Operate { get; set; }

    public short Paused { get; set; }

    public string? Descr { get; set; }

    public string Xuser { get; set; } = null!;

    public DateTime Di { get; set; }

    public short? Timout { get; set; }

    public int? MId { get; set; }
}
