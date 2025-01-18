using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Parcel.API.Controllers
{
    [Route("api/parcel")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetParcel(string id)
        {
            return Ok(id);
        }
    }
}
