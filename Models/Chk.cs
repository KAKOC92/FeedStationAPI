using System;
using System.Collections.Generic;

namespace FDAPI.Models;

public partial class Chk
{
    public int Rid { get; set; }

    public string? Chip { get; set; }

    public short? Numstation { get; set; }

    public short? Numgroup { get; set; }

    public DateTime? Dat { get; set; }

    public DateTime? Datetimein { get; set; }

    public DateTime? Datetimeout { get; set; }

    public float? Totalfeed { get; set; }

    public string? Tatno { get; set; }

    public short? Rat { get; set; }

    public float? Masin { get; set; }

    public float? Masout { get; set; }

    public int? Animid { get; set; }

    public int? BulkId { get; set; }

    public DateTime Di { get; set; }

    public short? StnType { get; set; }

    public short Xmode { get; set; }
}
