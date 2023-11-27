using Microsoft.AspNetCore.Mvc;

namespace NumeroDaSorte.Controllers
{
    [ApiController]
    [Route("NumeroSorte")]
    public class NumeroDaSorte : ControllerBase
    {        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<int>> GetNumeroDaSorteAsync()
        {
            Random random = new Random();
            var numeroAleatorio = random.Next(1, 101);
            return Ok(numeroAleatorio);
        }      
    }
}
