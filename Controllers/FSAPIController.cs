using FDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        public async Task<JsonResult> GetByNumstation(FSAPIContext context, int numstation )
        {
            var result = context.Chks.Where(x=>x.Numstation==numstation);
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
                context.GetChk.Add(item);
                await context.SaveChangesAsync();
                return new JsonResult(Ok());

            }
            catch (Exception ex)
            {
                return new JsonResult(StatusCode(500));
            }
        }

        [HttpPost("{id}")]
        public async Task<JsonResult> UpdateQuiz(FSAPIContext context, Chk item)
        {
            try
            {
                var result = await context.GetChk.FindAsync(item.Rid);
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
        
    }
}
