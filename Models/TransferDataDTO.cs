using FDAPI.Models;

public class TransferDataDTO
{
    public int kid { get; set; }

    public DateTime? xtime { get; set; }

    public float proto { get; set; }

    public String xver { get; set; }

    public OperationType stntoiisop { get; set; }

    public int msgid { get; set; }
    
    public addTdataDTO[] Chk { get; set;}                      

}

public enum OperationType                                     //тут параметры из “« п.3,4
{
    operate, settime, tdata, lamp1On, lamp1Off
}

public class addTdataDTO
{
    public DateTime? Datetimeout { get; set; }  // врем€ окончани€ кормлени€

    public string? Chip { get; set; }          // номер транспондера

    public float? Totalfeed { get; set; }      // масса корма

    public int Duration { get; set; }          //длительность (сек.);

    public short Xmode { get; set; }         // режим (приучение=1; кормление=0).

    public short? Numstation { get; set; }
}

public class StatlogDTO
{
    public String kid { get; set; }

    public String xtime { get; set; }

    public String proto { get; set; }

    public String xver { get; set; }

    public String stntoiisop { get; set; }

    public string? xip { get; set; }

    public string? xua { get; set; }

    public short err {  get; set; }

    //public String msgid { get; set; }     //код сообщени€, пока не пишем   

}