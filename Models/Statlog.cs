using System;
using System.Collections.Generic;

namespace FDAPI.Models;

public partial class Statlog
{
    public long Rid { get; set; }

    public short Stid { get; set; }

    public string Kid { get; set; } = null!;

    public string? Kod { get; set; }

    public string? Xtime { get; set; }

    public string? Op { get; set; }

    public short Tmaut { get; set; }

    public string Xuser { get; set; } = null!;

    public DateTime Di { get; set; }

    public string? Xip { get; set; }

    public string? Xua { get; set; }

    public string? Key1 { get; set; }

    public string? Val1 { get; set; }

    public string? Key2 { get; set; }

    public string? Val2 { get; set; }

    public short Xerr { get; set; }

    public string? Proto { get; set; }

    public string? Xver { get; set; }

    public short? Errcod { get; set; }
}
