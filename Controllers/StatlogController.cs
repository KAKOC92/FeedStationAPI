using FDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDAPI.Controllers
{
    public class StatlogController : ControllerBase
    {
        [HttpGet("api/controller/statlog/id")]
        public async Task<JsonResult> GetByKid(StatlogContext context, int id)
        {
            var result = await context.GetStatlogs.FindAsync(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(result);
        }
    }
}
// Загуглисть про битрикс24
// использовать 1 контроллер, это контроллер можно удалить
