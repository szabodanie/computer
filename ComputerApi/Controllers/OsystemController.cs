using ComputerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerApi.Controllers
{
    [Route("osystems")]
    [ApiController]
    public class OsystemController : ControllerBase
    {
        private readonly ComputerContext computerContext;

        public OsystemController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }
        [HttpPost]
        public async Task<ActionResult<Osystem>> Post(CreateOsysytemDto createOsysytemDto)
        {
            var os = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = createOsysytemDto.Name,
                CreatedTime = DateTime.Now
            };
            if(os!= null)
            {
                await computerContext.Osystems.AddAsync(os);
                await computerContext.SaveChangesAsync();
                return StatusCode(201, os);

            }
           return BadRequest();
        }
    }
}
