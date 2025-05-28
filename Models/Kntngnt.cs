using System;
using System.Collections.Generic;

namespace FDAPI.Models;

public partial class Kntngnt
{
    public int Bid { get; set; }

    public int? Animid { get; set; }

    public DateOnly Bdate { get; set; }

    public DateOnly? Dateon { get; set; }

    public string Cpn { get; set; } = null!;

    public int? Cpn2 { get; set; }

    public short? Stn { get; set; }

    public string? Stn2 { get; set; }

    public DateOnly? Dateoff { get; set; }

    public DateOnly? Dateoff2 { get; set; }

    public string? Descr { get; set; }

    public int? Oprtr { get; set; }

    public string Xuser { get; set; } = null!;

    public DateTime Di { get; set; }
}
