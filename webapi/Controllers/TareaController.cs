using Microsoft.AspNetCore.Mvc;
using ProyectoEF.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("[controller]")]
    public class TareaController : ControllerBase
    {
        ITareaService tareaService;

        public TareaController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }

    }
}
