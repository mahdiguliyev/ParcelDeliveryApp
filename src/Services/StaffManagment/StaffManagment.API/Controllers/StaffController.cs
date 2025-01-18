using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StaffManagment.API.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetStaff(string id)
        {
            return Ok(id);
        }
    }
}
