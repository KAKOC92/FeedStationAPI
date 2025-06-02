using FDAPI.Models;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
//using FSAPIHelpers;
using Newtonsoft.Json;




namespace FeedStationWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FSAPIController : ControllerBase
    {


        [HttpGet]
        public async Task<JsonResult> GetFeedStationList(FSAPIContext context)
        {
            return new JsonResult(await context.Chks.ToListAsync());
        }

        [HttpGet("api/controller/chks/id")]
        public async Task<JsonResult> GetByRid(FSAPIContext context, int id)
        {
            var result = await context.Chks.FindAsync(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpGet("api/controller/chks/numstation")]
        public async Task<JsonResult> GetByNumstation(FSAPIContext context, int numstation)
        {
            var result = context.Chks.Where(x => x.Numstation == numstation);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpGet("api/controller/chks/chip")]
        public async Task<JsonResult> GetByChip(FSAPIContext context, string chip)
        {
            var result = context.Chks.Where(x => x.Chip == chip);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpGet("api/controller/chks/animid")]
        public async Task<JsonResult> GetByAnimId(FSAPIContext context, int animid)
        {
            var result = context.Chks.Where(x => x.Animid == animid);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpGet("api/controller/chks/tatno")]
        public async Task<JsonResult> GetByTatno(FSAPIContext context, string tatno)
        {
            var result = context.Chks.Where(x => x.Tatno == tatno);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteFeedStation(FSAPIContext context, int id)
        {
            try
            {
                var result = new Chk() { Rid = id };
                context.Chks.Attach(result);
                context.Chks.Remove(result);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500));
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddData(FSAPIContext context, Chk item)
        {
            try
            {
                context.Chks.Add(item);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());

            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500));
            }
        }

        [HttpPost("{id}")]
        public async Task<JsonResult> UpdateData(FSAPIContext context, Chk item)
        {
            try
            {
                var result = await context.Chks.FindAsync(item.Rid);
                if (result != null)
                {
                    result.Rid = item.Rid;
                    result.Numstation = item.Numstation;
                    result.Chip = item.Chip;
                    result.Animid = item.Animid;
                    result.Tatno = item.Tatno;
                    result.Numgroup = item.Numgroup;
                    result.Totalfeed = item.Totalfeed;
                    result.Rat = item.Rat;
                    result.Masin = item.Masin;
                    result.Masout = item.Masout;
                    result.BulkId = item.BulkId;
                    result.StnType = item.StnType;
                    result.Xmode = item.Xmode;
                    await context.SaveChangesAsync();
                    return new JsonResult(Ok());
                }
                else
                    return new JsonResult(NotFound());
            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500), ex);
            }
        }
        

           [HttpGet("api/controller/statlog/id")]
            public async Task<JsonResult> GetByKid(FSAPIContext context, long id)
            {
                var result = await context.Statlogs.FindAsync(id);
                if (result == null)
                {
                    return new JsonResult(NotFound());
                }
                return new JsonResult(result);
            }
              
        private async Task AddOperateRecords(FSAPIContext context, TransferDataDTO dto)
        {
            Statlog statlog = new Statlog();
            statlog.Kid = dto.kid.ToString();
            statlog.Xtime = dto.xtime.ToString();
            statlog.Op = dto.stntoiisop.ToString();
            statlog.Proto = dto.proto.ToString();
            statlog.Xver = dto.xver.ToString();
            await context.Statlogs.AddAsync(statlog);
            await context.SaveChangesAsync();
        }

        private async  Task AddSetTime(FSAPIContext context, TransferDataDTO dto)
        {
            Statlog statlog = new Statlog();
            statlog.Xtime = dto.xtime.ToString();
            statlog.Kid = dto.kid.ToString();
            statlog.Proto = dto.proto.ToString();
            statlog.Xver = dto.xver.ToString();
            statlog.Op = dto.stntoiisop.ToString();                                          
            context.Statlogs.AddAsync(statlog);
            await context.SaveChangesAsync();
        }

        private async Task addTdata(FSAPIContext context, TransferDataDTO dto)
        {
            foreach (addTdataDTO chk in dto.Chk)
            {
                Chk chk1 = new Chk();
                chk1.Datetimeout = chk.Datetimeout;
                chk1.Chip = chk.Chip;
                chk1.Totalfeed = chk.Totalfeed;
                chk1.Datetimein = chk.Datetimeout.Value.AddSeconds (-chk.Duration);
                chk1.Xmode = chk.Xmode;
                chk1.Numstation = chk.Numstation;
                chk1.Animid = 333555;
                chk1.Tatno = "tatoo";
                context.Chks.AddAsync(chk1);                                        
            }                       
             await context.SaveChangesAsync();
        }

        //ќт 26 ма€
        
        //»з запроса сеттайм вытащить номер станции, залезть по нему в базу и вытащить значение таймаут
        // если станции нет вернуть таймаут 300
        // ƒобавить модель дл€ станций см скафолд с индусом
        // ¬сЄ должно писатьс€ в базу до среды
        
        // 28 ма€
        // ѕотучить ip адрес
        // «амодлить таб с животными
        // получили тдата-обрабатываем массив циклом-берем номер чипа-по чипу ищем св€зку чип+животное в knght и ищем запить об этом
        // ищем в cpn1 и cpn2, если запись есть, достаЄм animid, animid добавл€ем в записть табл расходов chk,
        // тату тоже достать из таблицы animal, если информации нет, то пол€ пустые (животное пришло в 1 раз),
        // когда новое животное св€з с чипом, в табл chk обновить записи и проставить animid и татуировку (апдейт после смены чипа)

        [HttpPost("api/controller/statlog")]  // Ёто основной метод
        
        public async Task<JsonResult> AllRecords(FSAPIContext context, object obj)
        {
            try
            {
                string jstr = JsonConvert.SerializeObject(obj);
                Console.WriteLine("----");
                Console.WriteLine(jstr);
                Console.WriteLine("----");

                dynamic preObj = JsonConvert.DeserializeObject<dynamic>(jstr)!;
                Console.WriteLine(preObj.stntoiisop);
                String stn = preObj.stntoiisop.ToString();
                switch (stn) { 
                    case "settime":  
                    case "operate":
                    case "err":
                    case "tdata":
                        {
                            DateTime time = DateTime.Parse(preObj.xtime.ToString());

                            StatlogDTO statlog = new StatlogDTO();
                            statlog.kid = preObj.kid;
                            statlog.xtime = time.ToString("s") + time.ToString("zzz");
                            statlog.stntoiisop = preObj.stntoiisop;
                            statlog.proto = preObj.proto;
                            statlog.xver = preObj.xver;
                            //statlog.xip = HttpContext.Request.Headers["X-Forwarded-For"];
                            //statlog.xip = Request.Headers["CF-CONNECTING-IP"];
                            //statlog.xip = HttpContext.Connection.RemoteIpAddress?.ToString();
                            statlog.xip = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
                            statlog.xua = Request.Headers["User-Agent"].ToString();
                            // ::1 это значение при локальном запуске кода,
                            // представл€ет собой сжатую версию адреса обратной св€зи IPV6,
                            // 0:0:0:0:0:0:0:1эквивалентного адресу IPV4 127.0.0.1.
                            // ѕри развертывании этого на веб-сервере где-либо IP
                            // изменитс€ на реальный IP клиента.
                            if (stn == "err") 
                            {
                             statlog.err = preObj.errcode;
                            }                                                  
                            StatlogRecord(context, statlog);
                            if (stn == "tdata")
                            {
                                return tDataRecords(context, preObj);
                            }

                            dynamic result = new System.Dynamic.ExpandoObject();
                            result.xtime = DateTime.UtcNow.ToString("s") + DateTime.UtcNow.ToString("zzz");
                            result.timaut = GetTimeOut(context, preObj.kid.ToString());
                            return new JsonResult(result);
                        }
                }
               
                return new JsonResult(Ok());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //выводит в консоль сообщение о том, что не так
                return new JsonResult(StatusCode(500));
            }
        }

        private JsonResult tDataRecords(FSAPIContext context, dynamic preObj)
        {
            foreach (var js in preObj.xdata)
            {
                try
                {
                    DateTime time1 = DateTime.Parse(js.ts.ToString());

                    Chk chk = new Chk();
                    chk.Chip = js.tag;
                    chk.Numstation = preObj.kid;
                    chk.Datetimein = js.ts;
                    chk.Datetimeout = time1.AddSeconds((double)js.dur);
                    chk.Totalfeed = js.mass;
                    chk.Xmode = js.mode;

                    //String tag = js.GetType().GetProperty("tag");
                    String tag = String.Empty;
                    try
                    {
                        tag = js.tag;
                    }
                    catch { }

                    if (!String.IsNullOrEmpty(tag))
                    {
                        Kntngnt kntngnt = context.Kntngnts.Where(x => x.Cpn.Equals(tag)).FirstOrDefault();

                        if (kntngnt != null)
                        {
                            chk.Animid = kntngnt.Animid;
                            Animal animal = context.Animals.Where(x => x.Animid == kntngnt.Animid).FirstOrDefault();
                            if (animal != null)
                            {
                                chk.Tatno = animal.Tag;
                            }
                        }


                        Console.WriteLine(js.tag);
                    }

                    context.Chks.Add(chk);

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            if (preObj.xdata.Count > 0)
            {
                context.SaveChanges();
            }
            dynamic result1 = new System.Dynamic.ExpandoObject();
            result1.xtime = DateTime.UtcNow.ToString("s") + DateTime.UtcNow.ToString("zzz");
            result1.timaut = GetTimeOut(context, preObj.kid.ToString());
            result1.tdata = "done";
            return new JsonResult(result1);
        }

        private short GetTimeOut(FSAPIContext context, String kid)
        {
            short result = 300;
            var stn = context.Stations.Where(x => x.Kid == kid).FirstOrDefault();
            if (stn != null)
            {
                result = (short)stn.Timout;
            }
            return result;
        }

        private  async void  StatlogRecord(FSAPIContext context, StatlogDTO dto)
        {
            Statlog statlog = new Statlog();
            statlog.Kid = dto.kid;
            statlog.Xtime = dto.xtime;
            statlog.Op = dto.stntoiisop;
            statlog.Proto = dto.proto;
            statlog.Xver = dto.xver;
            statlog.Xip = dto.xip;
            statlog.Xua = dto.xua;
            statlog.Errcod = dto.err;
            context.Statlogs.Add(statlog);
            context.SaveChanges();
        }

        //private async void TdataRecord(FSAPIContext context, KntngntDTO dto)
        //{
        //    Kntngnt kntngnt = new Kntngnt();
        //    kntngnt.Bid = dto.bid;
        //    kntngnt.Animid = dto.animid;
        //    kntngnt.Cpn = dto.cpn;
        //    kntngnt.Cpn2 = dto.cpn2;
        //    context.Add(kntngnt);// вот тут посмотреть
        //    context.SaveChanges();
            
        //}

        
    }
}