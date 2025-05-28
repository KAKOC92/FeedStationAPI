using System;
using System.Collections.Generic;

namespace FDAPI.Models;

public partial class Animal
{
    public int Animid { get; set; }

    public int? Litter { get; set; }

    public short? Pn { get; set; }

    public string? Tag { get; set; }

    public string? Reg { get; set; }

    public string? Elreg { get; set; }

    public string? Reg2 { get; set; }

    public short? Sex { get; set; }

    public short? Status { get; set; }

    public string? Name { get; set; }

    public short? BoarLine { get; set; }

    public short? SowLine { get; set; }

    public short Stado { get; set; }

    public int? Boar { get; set; }

    public int? Sow { get; set; }

    public short? Poroda { get; set; }

    public short? Ferma { get; set; }

    public short? Korpus { get; set; }

    public short? Zal { get; set; }

    public short? Stan { get; set; }

    public int? SublineId { get; set; }

    public short? Lteats { get; set; }

    public short? Rteats { get; set; }

    public int? Farrow { get; set; }

    public DateOnly? Brdate { get; set; }

    public float? Brweight { get; set; }

    public float? Wnweight { get; set; }

    public DateOnly? Indate { get; set; }

    public string? Comments { get; set; }

    public DateOnly? Outdate { get; set; }

    public int? Remres { get; set; }

    public int? Remres2 { get; set; }

    public int? Dres { get; set; }

    public int? Dres2 { get; set; }

    public short? Removed { get; set; }

    public short Pdg { get; set; }

    public string? Sublinegen { get; set; }

    public short? Metodv { get; set; }

    public DateOnly? Stdate { get; set; }

    public bool? Isanimal { get; set; }

    public bool? Deleted { get; set; }
}
