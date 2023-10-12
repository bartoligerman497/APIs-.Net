using Microsoft.AspNetCore.Mvc;
using ProyectoEF;
using webapi.Services;
using static webapi.Services.HelloworldService;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldcontroller : ControllerBase
    {
        IHelloWorldService helloWorldService;
        TareasContext dbcontext;

        // http://localhost:5183/helloworld
        public HelloWorldcontroller(IHelloWorldService helloWorld, TareasContext dbcontext)
        {
            helloWorldService = helloWorld;
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase() {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }
    }
}
